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
    public class FileTypeController : ControllerBase
    {
        private readonly HcmutSspsContext _context;
        private readonly IFileTypeRepository _fileTypeRepository;

        public FileTypeController(HcmutSspsContext context, IFileTypeRepository fileTypeRepository) { 
            _context = context;
            _fileTypeRepository = fileTypeRepository;
        }

        [HttpGet]
        [Route("get-list-file-type")]
        public async Task<IActionResult> GetFileTypes(string? keyword = "", int pageNumber = 1, int per_page = 6)
        {
            ResultViewModel Result = new ResultViewModel();
            Result = await _fileTypeRepository.GetFileTypes(keyword, pageNumber, per_page);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Result);
        }

        [HttpPost]
        [Route("create-file-type")]
        public async Task<IActionResult> CreateFileType(string typeName)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _fileTypeRepository.CreateFileType(typeName);
            return Ok(Result);
        }

        [HttpPost]
        [Route("update-file-type")]
        public async Task<IActionResult> UpdateFileType(Guid id, string typeName)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _fileTypeRepository.UpdateFileType(id, typeName);
            return Ok(Result);
        }

        [HttpPost]
        [Route("delete-file-type")]
        public async Task<IActionResult> DeleteFileType(Guid id)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _fileTypeRepository.DeleteFileType(id);
            return Ok(Result);
        }
    }
}
