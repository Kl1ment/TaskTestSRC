using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DistrictRepository(SRCDbContext context) : IDistrictRepository
    {
        private const int PageSize = 10;

        public async Task<Result> AddAsync(District district)
        {
            try
            {
                var districtEntity = new DistrictEntity
                {
                    Id = district.Id,
                    Number = district.Number,
                };

                await context.Districts.AddAsync(districtEntity);
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<List<District>> GetAllAsync(int page)
        {
            var districtEntities = await context.Districts
                .AsNoTracking()
                .Skip(page - 1)
                .Take(PageSize)
                .ToListAsync();

            return districtEntities.Select(s => District.Create(
                s.Id,
                s.Number)).ToList();
        }

        public async Task<Result> DeleteAsync(int number)
        {
            try
            {
                await context.Districts
                    .Where(d => d.Number == number)
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
