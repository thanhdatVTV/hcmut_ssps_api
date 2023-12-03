namespace HCMUT_SSPS.ViewModels.ResultView
{
    public class ResponsePagePurchaseModel
    {
        public int Id { get; set; }

        public Guid? UserId { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public int? PageCount { get; set; }

        public int? PaymentStatus { get; set; }

        public bool? IsDelete { get; set; }
    }
}
