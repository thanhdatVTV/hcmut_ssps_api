namespace HCMUT_SSPS.ViewModels.ResultView
{
    public class PageSizeResponseViewModel
    {
        public List<ResponsePageSizeModel> PageSizes { get; set; }
        public int Page { get; set; }    //trang hien tai
        public int PerPage { get; set; }   //so item cua moi trang
        public int Total { get; set; }     // ton so record
        public int TotalPages { get; set; }  //tong so trang
    }
    public class ResponsePageSizeModel
    {
        public string? PageSizeName { get; set; }

        public int Id { get; set; }
    }
}
