using HCMUT_SSPS.ViewModels.ResultView;

namespace HCMUT_SSPS.Interfaces
{
    public interface IPrinterRepository
    {
        public Task<ResultViewModel> GetPrinters(string? keyword = "", int pageNumber = 1, int per_page = 6);
        public Task<ResultViewModel> CreatePrinter(string brand, string printerModel, string description);
        public Task<ResultViewModel> UpdatePrinter(Guid id, string brand, string printerModel, string description);
        public Task<ResultViewModel> DeletePrinter(Guid id);
    }
}
