using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CabinetController(ICabinetService cabinetService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CabinetResponse>>> GelAllCabinets(int page)
        {
            var cabinets = await cabinetService.GetAllCabinetsAsync(page);

            return cabinets.Select(s => new CabinetResponse(
                s.Id,
                s.Number)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCabinet(CabinetCreate cabinetCreate)
        {
            var result = await cabinetService.AddCabinetAsync(
                cabinetCreate.Number);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCabinet(int number)
        {
            var result = await cabinetService.DeleteCabinetAsync(number);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
