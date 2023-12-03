using HCMUT_SSPS.ViewModels.ResultView;

namespace HCMUT_SSPS.Interfaces
{
    public interface IPagePurchaseRepository
    {
        public Task<ResultViewModel> GetPageCount(string codeId);
        public Task<ResultViewModel> UpdatePageCount(Guid userId, int pageCount);
        public Task<ResultViewModel> CreatePageCount(Guid userId, int pageCount);
    }
}
