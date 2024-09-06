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
        public async Task<ActionResult<List<DistrictResponse>>> GelAllDistricts(int page)
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

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDistrict(int number)
        {
            var result = await districtService.DeleteDistrictAsync(number);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
