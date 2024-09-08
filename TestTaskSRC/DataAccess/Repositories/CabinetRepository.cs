using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CabinetRepository(SRCDbContext context) : ICabinetRepository
    {
        private const int PageSize = 10;

        public async Task<Result> AddAsync(Cabinet cabinet)
        {
            try
            {
                var cabinetEntity = new CabinetEntity
                {
                    Id = cabinet.Id,
                    Number = cabinet.Number,
                };

                await context.Cabinets.AddAsync(cabinetEntity);
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<List<Cabinet>> GetAllAsync(int page)
        {
            var cabinetEntities = await context.Cabinets
                .AsNoTracking()
                .Skip(page - 1)
                .Take(PageSize)
                .ToListAsync();

            return cabinetEntities.Select(c => Cabinet.Create(
                c.Id,
                c.Number)).ToList();
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                await context.Cabinets
                    .Where(c => c.Id == id)
                    .Include(c => c.Doctors)
                    .ExecuteDeleteAsync();

                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
