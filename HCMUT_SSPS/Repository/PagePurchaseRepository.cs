using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HCMUT_SSPS.Repository
{
    public class PagePurchaseRepository : IPagePurchaseRepository
    {
        private readonly HcmutSspsContext _context;

        public PagePurchaseRepository(HcmutSspsContext context) {
            _context = context;
        }

        

        public async Task<ResultViewModel> GetPageCount(string codeId)
        {
            ResultViewModel model = new ResultViewModel();

            try
            {
                var userId = await _context.TblUsers.Where(d => d.CodeId == codeId).Select(d => d.Id).FirstOrDefaultAsync();
                var pagePurchase = await _context.TblPagePurchases.Where(d => d.UserId == userId).FirstOrDefaultAsync();

                if(pagePurchase != null) {
                    ResponsePagePurchaseModel PagePurchaseViewModel = new ResponsePagePurchaseModel()
                    {
                        UserId = pagePurchase.UserId,
                        PurchaseDate = pagePurchase.PurchaseDate,
                        PageCount = pagePurchase.PageCount,
                        PaymentStatus = pagePurchase.PaymentStatus,

                    };
                model.response = PagePurchaseViewModel;
                }


            }
            catch (Exception ex)
            {
                model.status = -1;
                model.message = "Service không hoạt động " + ex.Message.ToString();
            }

            return model;
        }

        public async Task<ResultViewModel> UpdatePageCount(string codeId, int pageCount)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var userId = await _context.TblUsers.Where(d => d.CodeId == codeId).Select(d => d.Id).FirstOrDefaultAsync();
                var pagePurchase = await _context.TblPagePurchases.Where(d => d.UserId == userId).FirstOrDefaultAsync();

                pagePurchase.PageCount = pageCount;
                pagePurchase.DateUpdated = DateTime.Now;
                await _context.SaveChangesAsync();
                model.response = pagePurchase;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> CreatePageCount(Guid userId, int pageCount)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var pagePurchase = new TblPagePurchase();
                pagePurchase.UserId = userId;
                pagePurchase.PageCount = pageCount;
                pagePurchase.UserCreated = userId;
                pagePurchase.DateCreated = DateTime.Now;
                _context.AddAsync(pagePurchase);
                await _context.SaveChangesAsync();
                model.response = pagePurchase;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

    }
}
