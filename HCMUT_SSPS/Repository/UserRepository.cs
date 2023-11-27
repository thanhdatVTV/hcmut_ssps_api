using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.EntityFrameworkCore;

namespace HCMUT_SSPS.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HcmutSspsContext _context;

        public UserRepository(HcmutSspsContext context) {
            _context = context;
        }

        

        public async Task<ResultViewModel> GetUsers (string? keyword, int page = 1, int per_page = 6)
        {
            ResultViewModel model = new ResultViewModel();

            try
            {
                UserResponseViewModel lstUserViewModel = new UserResponseViewModel();

                var query = await _context.TblUsers.ToListAsync();

                if (keyword != null && keyword != "")
                {
                    query = query.Where(u => u.FullName.Contains(keyword)).ToList();
                }

                lstUserViewModel.Total = query.Count();
                lstUserViewModel.Page = page;
                lstUserViewModel.PerPage = per_page;
                lstUserViewModel.TotalPages = lstUserViewModel.Total / per_page;

                var results = query.Select(u => new ResponseUserModel
                {   
                    CodeId = u.CodeId,
                    LastName = u.LastName,
                    FirstName = u.FirstName,
                    FullName = u.FullName,
                    DateOfBirth = u.DateOfBirth,
                    Type = (int)u.Type,
                    CourseName = u.CourseName,
                    FacultyName = u.FacultyName
                }).ToList();

                lstUserViewModel.Users = results;

                model.status = 1;
                model.message = "Get list user success!";
                model.response = lstUserViewModel;
            }
            catch (Exception ex)
            {
                model.status = -1;
                model.message = "Service không hoạt động " + ex.Message.ToString();
            }

            return model;
        }

        public async Task<ResultViewModel> UpdateUser(Guid id, string lastName, string firstName)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var user = await _context.TblUsers.Where(d => d.Id == id).FirstOrDefaultAsync();

                user.LastName = lastName;
                user.FirstName = firstName;
                user.FullName = lastName + " " + firstName;
                await _context.SaveChangesAsync();
                model.response = user;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> CreateUser(string codeId, string lastName, string firstName, string fullName, int facultyId, string facultyName, int courseId, string courseName, DateTime dayOfBirth, int type)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                Guid id = Guid.NewGuid();
                var user = new TblUser();
                user.Id = id;
                user.CodeId = codeId;
                user.LastName = lastName;
                user.FirstName = firstName;
                user.FullName = fullName;
                user.CourseId = courseId;
                user.CourseName = courseName;
                user.FacultyId = facultyId;
                user.FacultyName = facultyName;
                user.Type = type;
                user.DateOfBirth = dayOfBirth;
                user.UserCreated = id;
                user.DateCreated = DateTime.Now;
                _context.AddAsync(user);
                await _context.SaveChangesAsync();
                model.response = user;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public Task<ResultViewModel> DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
