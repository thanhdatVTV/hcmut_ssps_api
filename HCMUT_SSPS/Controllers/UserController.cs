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
    public class UserController : ControllerBase
    {
        private readonly HcmutSspsContext _context;
        private readonly IUserRepository _userRepository;

        public UserController(HcmutSspsContext context, IUserRepository userRepository) { 
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string userName, string passWord)
        {
            ResultViewModel resultViewModel = new ResultViewModel();

            //string apiUrl = "https://localhost:44398/api/User/get-by-id?userName=dat.nguyen2233167&passWord=123456";
            string apiUrl = "https://localhost:44398/api/User/get-by-id?userName=" + userName + "&passWord=" + passWord;

            using (HttpClient client = new HttpClient())
            {
                // You can set headers if needed
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer YourAccessToken");

                HttpResponseMessage response = await client.GetAsync($"{apiUrl}");

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    UserResponseViewModel userResponse = JsonConvert.DeserializeObject<UserResponseViewModel>(result);
                    resultViewModel.status = 1;
                    resultViewModel.message = "thanh cong";
                    resultViewModel.response = userResponse;
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }

             
            return Ok(resultViewModel);
        }

        [HttpGet]
        [Route("get-list-user")]
        public async Task<IActionResult> GetListUsers(string? keyword, int pageNumber = 1, int per_page = 6)
        {
            ResultViewModel Result = new ResultViewModel();
            Result = await _userRepository.GetUsers(keyword, pageNumber, per_page);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Result);
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser(string codeId, string lastName, string firstName, string fullName, int facultyId, string FacultyName, int CourseId, string CourseName, DateTime DayOfBirth, int type)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _userRepository.CreateUser(codeId, lastName, firstName, fullName, facultyId, FacultyName, CourseId, CourseName, DayOfBirth, type);
            return Ok(Result);
        }

        [HttpPost]
        [Route("update-user")]
        public async Task<IActionResult> UpdateUser(Guid id, string lastName, string firstName)
        {
            ResultViewModel Result = new ResultViewModel();
            //_logger.LogInformation($"Create customers");
            Result = await _userRepository.UpdateUser(id, lastName, firstName);
            return Ok(Result);
        }
    }
}
