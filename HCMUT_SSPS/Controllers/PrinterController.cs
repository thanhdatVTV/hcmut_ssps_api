using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.AspNetCore.Mvc;

namespace HCMUT_SSPS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrinterController : ControllerBase
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterController(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }

        //[HttpGet]
        //[Route("get-list-printer")]
        //public async Task<IActionResult> GetListPrinters(string? keyword, int pageNumber = 1, int per_page = 6)
        //{
        //    ResultViewModel result = new ResultViewModel();
        //    result = await _printerRepository.GetPrinters(keyword, pageNumber, per_page);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return Ok(result);
        //}

        [HttpPost]
        [Route("create-printer")]
        public async Task<IActionResult> CreatePrinter(string brand, string model, string description, int locationId, int status)
        {
            ResultViewModel result = new ResultViewModel();
            result = await _printerRepository.AddPrinter(brand, model, description, locationId, status);

            return Ok(result);
        }

        [HttpPost]
        [Route("update-printer")]
        public async Task<IActionResult> UpdatePrinter(Guid id, string brand, string model, string description, int locationId, int status)
        {
            ResultViewModel result = new ResultViewModel();
            result = await _printerRepository.UpdatePrinter(id, brand, model, description, locationId, status);

            return Ok(result);
        }

        [HttpPost]
        [Route("delete-printer")]
        public async Task<IActionResult> DeletePrinter(Guid id)
        {
            ResultViewModel result = new ResultViewModel();
            result = await _printerRepository.DeletePrinter(id);

            return Ok(result);
        }
    }
}
