using HCMUT_SSPS.ViewModels.ResultView;

namespace HCMUT_SSPS.Interfaces
{
    public interface IPagePurchaseRepository
    {
        public Task<ResultViewModel> GetPageCount(Guid userId);
        public Task<ResultViewModel> UpdatePageCount(Guid userId, int pageCount);
        public Task<ResultViewModel> CreatePageCount(Guid userId, int pageCount);
    }
}
