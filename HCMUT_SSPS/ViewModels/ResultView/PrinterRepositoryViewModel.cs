namespace HCMUT_SSPS.ViewModels.ResultView
{
    public class PrinterRepositoryViewModel
    {
        public List<ResponsePrinterModel> Printer { get; set; }
        public int Page { get; set; }    //trang hien tai
        public int PerPage { get; set; }   //so item cua moi trang
        public int Total { get; set; }     // ton so record
        public int TotalPages { get; set; }  //tong so trang
        public List<ResponsePrinterModel> Printers { get; internal set; }
    }

    public class ResponsePrinterModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int Status { get; set; }
        public bool IsDelete { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DataCreated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
