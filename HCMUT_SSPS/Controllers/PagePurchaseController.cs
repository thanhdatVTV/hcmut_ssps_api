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
    public class PagePurchaseController : ControllerBase
    {
        private readonly HcmutSspsContext _context;
        private readonly IPagePurchaseRepository _pagePurchaseRepository;

        public PagePurchaseController(HcmutSspsContext context, IPagePurchaseRepository pagePurchaseRepository) { 
            _context = context;
            _pagePurchaseRepository = pagePurchaseRepository;
        }

        [HttpGet]
        [Route("get-page-count")]
        public async Task<IActionResult> GetPageCount(string codeId)
        {
            ResultViewModel Result = new ResultViewModel();
            Result = await _pagePurchaseRepository.GetPageCount(codeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Result);
        }

        [HttpPost]
        [Route("create-page-count")]
        public async Task<IActionResult> CreatePageCount(Guid userId, int pageCount)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _pagePurchaseRepository.CreatePageCount(userId, pageCount);
            return Ok(Result);
        }

        [HttpPost]
        [Route("update-page-count")]
        public async Task<IActionResult> UpdatePageCount(Guid userId, int pageCount)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _pagePurchaseRepository.UpdatePageCount(userId, pageCount);
            return Ok(Result);
        }
    }
}
