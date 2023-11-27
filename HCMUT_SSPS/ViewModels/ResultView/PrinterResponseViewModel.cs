namespace HCMUT_SSPS.ViewModels.ResultView
{
    public class PrinterResponseViewModel
    {
        public List<ResponsePrinterModel> Printers { get; set; }
        public int Page { get; set; }    //trang hien tai
        public int PerPage { get; set; }   //so item cua moi trang
        public int Total { get; set; }     // ton so record
        public int TotalPages { get; set; }  //tong so trang
    }
    public class ResponsePrinterModel
    {
        public Guid Id { get; set; }
        public string? Brand { get; set; }

        public string? PrinterModel { get; set; }

        public string? Description { get; set; }
    }
}
