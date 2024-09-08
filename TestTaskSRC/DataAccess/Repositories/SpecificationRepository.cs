using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SpecificationRepository(SRCDbContext context) : ISpecificationRepository
    {
        private const int PageSize = 10;

        public async Task<Result> AddAsync(Specification specification)
        {
            try
            {
                var specificationEntity = new SpecificationEntity
                {
                    Id = specification.Id,
                    Name = specification.Name,
                };

                await context.Specifications.AddAsync(specificationEntity);
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<List<Specification>> GetAllAsync(int page)
        {
            var specificationEntities = await context.Specifications
                .AsNoTracking()
                .Skip(page - 1)
                .Take(PageSize)
                .ToListAsync();

            return specificationEntities.Select(s => Specification.Create(
                s.Id,
                s.Name)).ToList();
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                await context.Specifications
                    .Where(s => s.Id == id)
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
