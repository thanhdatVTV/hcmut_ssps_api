using HCMUT_SSPS.ViewModels.ResultView;

namespace HCMUT_SSPS.Interfaces
{
    public interface IPrinterRepository
    {
        Task<PrinterRepositoryViewModel> GetPrinters(string? keyword, int pageNumber = 1, int per_page = 6);
        Task<ResultViewModel> AddPrinter(string brand, string model, string description, int locationId, int status);
        Task<ResultViewModel> UpdatePrinter(Guid id, string brand, string model, string description, int locationId, int status);
        Task<ResultViewModel> DeletePrinter(Guid id);
    }
}
