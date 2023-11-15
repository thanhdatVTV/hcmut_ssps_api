using HCMUT_SSPS.ViewModels.ResultView;

namespace HCMUT_SSPS.Interfaces
{
    public interface IUserRepository
    {
        public Task<ResultViewModel> GetUsers(string keyword = "", int pageNumber = 1, int per_page = 6);
        public Task<ResultViewModel> CreateUser(string codeId, string lastName, string firstName, string fullName, int facultyId, string FacultyName, int CourseId, string CourseName, DateTime DayOfBirth, int type);
        public Task<ResultViewModel> UpdateUser(Guid id, string lastName, string firstName);
        public Task<ResultViewModel> DeleteUser();
    }
}
