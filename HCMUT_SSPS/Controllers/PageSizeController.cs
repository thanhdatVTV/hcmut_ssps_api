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
    public class PageSizeController
        : ControllerBase
    {
        private readonly HcmutSspsContext _context;
        private readonly IPageSizeRepository _pageSizeRepository;

        public PageSizeController(HcmutSspsContext context, IPageSizeRepository pageSizeRepository)
        {
            _context = context;
            _pageSizeRepository = pageSizeRepository;
        }

        [HttpGet]
        [Route("get-list-page-size")]
        public async Task<IActionResult> GetPageSizes(string? keyword, int pageNumber = 1, int per_page = 6)
        {
            ResultViewModel Result = new ResultViewModel();
            Result = await _pageSizeRepository.GetPageSizeList(keyword, pageNumber, per_page);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Result);
        }

        [HttpPost]
        [Route("create-page-size")]
        public async Task<IActionResult> CreatePageSize(string pageSizeName)
        {
            ResultViewModel Result = new ResultViewModel();
           
            //_logger.LogInformation($"Create customers");
            Result = await _pageSizeRepository.CreatePageSize(pageSizeName);
            return Ok(Result);
        }

        [HttpPost]
        [Route("update-page-size")]
        public async Task<IActionResult> UpdatePageSize(int id, string pageSizeName)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _pageSizeRepository.UpdatePageSize(id, pageSizeName);
            return Ok(Result);
        }

        [HttpPost]
        [Route("delete-page-size")]
        public async Task<IActionResult> DeletePageSize(int id)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _pageSizeRepository.DeletePageSize(id);
            return Ok(Result);
        }
    }
}
