using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecificationController(ISpecificationService specificationService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SpecificationResponse>>> GelAllSpecifications(int page)
        {
            var specifications = await specificationService.GetAllSpecificationsAsync(page);

            return specifications.Select(s => new SpecificationResponse(
                s.Id,
                s.Name)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateSpecification(SpecificationCreate specificationCreate)
        {
            var result = await specificationService.AddSpecificationAsync(
                specificationCreate.Name);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDistrict(string name)
        {
            var result = await specificationService.DeleteSpecificationAsync(name);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
