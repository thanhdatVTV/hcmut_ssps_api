namespace HCMUT_SSPS.ViewModels.ResultView
{
    public class FileTypeResponseViewModel
    {
        public List<ResponseFileTypeModel> FileTypes { get; set; }
        public int Page { get; set; }    //trang hien tai
        public int PerPage { get; set; }   //so item cua moi trang
        public int Total { get; set; }     // ton so record
        public int TotalPages { get; set; }  //tong so trang
    }
    public class ResponseFileTypeModel
    {
        public string? TypeName { get; set; }
    }
}
