using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace HCMUT_SSPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {
        private readonly HcmutSspsContext _context;
        private readonly IPrinterRepository _printerRepository;

        public PrinterController(HcmutSspsContext context, IPrinterRepository printerRepository) { 
            _context = context;
            _printerRepository = printerRepository;
        }

        [HttpGet]
        [Route("get-list-printer")]
        public async Task<IActionResult> GetPrinters(string? keyword = "", int pageNumber = 1, int per_page = 6)
        {
            ResultViewModel Result = new ResultViewModel();
            Result = await _printerRepository.GetPrinters(keyword, pageNumber, per_page);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Result);
        }

        [HttpPost]
        [Route("create-printer")]
        public async Task<IActionResult> CreatePrinter(string brand, string printerModel, string description)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _printerRepository.CreatePrinter(brand, printerModel, description);
            return Ok(Result);
        }

        [HttpPost]
        [Route("update-printer")]
        public async Task<IActionResult> UpdatePrinter(Guid id, string brand, string printerModel, string description)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _printerRepository.UpdatePrinter(id, brand, printerModel, description);
            return Ok(Result);
        }

        [HttpPost]
        [Route("delete-printer")]
        public async Task<IActionResult> DeletePrinter(Guid id)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _printerRepository.DeletePrinter(id);
            return Ok(Result);
        }
    }
}
