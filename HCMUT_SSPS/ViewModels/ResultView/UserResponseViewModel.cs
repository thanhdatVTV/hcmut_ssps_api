namespace HCMUT_SSPS.ViewModels.ResultView
{
    public class UserResponseViewModel
    {
        public List<ResponseUserModel> Users { get; set; }
        public int Page { get; set; }    //trang hien tai
        public int PerPage { get; set; }   //so item cua moi trang
        public int Total { get; set; }     // ton so record
        public int TotalPages { get; set; }  //tong so trang
    }
    public class ResponseUserModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Fullname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Type { get; set; }
        //Teacher
        public string TeacherId { get; set; }
        public string CourseName { get; set; }
        //Sudent
        public string FacultyName { get; set; }
        public string StudentId { get; set; }
    }
}
