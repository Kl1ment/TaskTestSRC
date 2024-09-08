using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistrictController(IDistrictService districtService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<DistrictResponse>>> GetAllDistricts(int page)
        {
            var district = await districtService.GetAllDistrictsAsync(page);

            return district.Select(s => new DistrictResponse(
                s.Id,
                s.Number)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateDistrict(DistrictCreate districtCreate)
        {
            var result = await districtService.AddDistrictAsync(
                districtCreate.Number);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return RedirectToAction(nameof(GetAllDistricts), new { page = 1});
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDistrict(Guid districtId)
        {
            var result = await districtService.DeleteDistrictAsync(districtId);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
