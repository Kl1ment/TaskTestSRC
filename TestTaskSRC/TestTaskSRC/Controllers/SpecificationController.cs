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
        public async Task<ActionResult<List<SpecificationResponse>>> GetAllSpecifications(int page)
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

            return RedirectToAction(nameof(GetAllSpecifications), new { page = 1 });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDistrict(Guid specificationId)
        {
            var result = await specificationService.DeleteSpecificationAsync(specificationId);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
