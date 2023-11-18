using HCMUT_SSPS.ViewModels.ResultView;

namespace HCMUT_SSPS.Interfaces
{
    public interface IPageSizeRepository
    {
        public Task<ResultViewModel> GetPageSizeList(string? keyword, int pageNumber = 1, int per_page = 6);
        public Task<ResultViewModel> CreatePageSize(string pageSizeName);
        public Task<ResultViewModel> UpdatePageSize(int id, string pageSizeName);
        public Task<ResultViewModel> DeletePageSize(int id);
    }
}
