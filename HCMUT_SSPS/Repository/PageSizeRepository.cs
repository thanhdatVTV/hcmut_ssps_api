using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HCMUT_SSPS.Repository
{
    public class PageSizeRepository : IPageSizeRepository
    {
        private readonly HcmutSspsContext _context;

        public PageSizeRepository(HcmutSspsContext context) {
            _context = context;
        }

        

        public async Task<ResultViewModel> GetPageSizeList(string? keyword, int page = 1, int per_page = 6)
        {
            ResultViewModel model = new ResultViewModel();

            try
            {
                PageSizeResponseViewModel listPageSizeViewModel = new PageSizeResponseViewModel();
                var queryCount = await _context.TblPageSizes.Where(d => d.IsDelete != true).ToListAsync();
                listPageSizeViewModel.Total = queryCount.Count();

                var query = await _context.TblPageSizes.Where(d => d.IsDelete != true).Skip(per_page * (page - 1)).Take(per_page).ToListAsync();

                var results = query.Select(u => new ResponsePageSizeModel
                {
                    PageSizeName = u.PageSizeName,
                    Id = u.Id
                }).ToList();

                listPageSizeViewModel.Page = page;
                listPageSizeViewModel.PerPage = per_page;
                listPageSizeViewModel.TotalPages = (int)Math.Ceiling((double)listPageSizeViewModel.Total / per_page);

                listPageSizeViewModel.PageSizes = results;


                model.status = 1;
                model.message = "Get list page size success!";
                model.response = listPageSizeViewModel;
            }
            catch (Exception ex)
            {
                model.status = -1;
                model.message = "Service không hoạt động " + ex.Message.ToString();
            }

            return model;
        }

        public async Task<ResultViewModel> UpdatePageSize(int id, string pageSizeName)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var pageSize = await _context.TblPageSizes.Where(d => d.Id == id).FirstOrDefaultAsync();

                var pageName = _context.TblPageSizes.Where(d => d.PageSizeName == pageSizeName).FirstOrDefault();
                if (pageName != null)
                {
                    model.status = 0;
                    model.message = "paper size da ton tai ";
                }
                else
                {
                    pageSize.PageSizeName = pageSizeName;
                    await _context.SaveChangesAsync();
                    model.response = pageSize;
                }
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> CreatePageSize(string pageSizeName)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var pageName = _context.TblPageSizes.Where(d => d.PageSizeName == pageSizeName).FirstOrDefault();
                if (pageName != null)
                {
                    model.status = 0;
                    model.message = "paper size da ton tai " ;
                }
                else
                {
                    Guid idUser = Guid.NewGuid();
                    var pageSize = new TblPageSize();
                    pageSize.PageSizeName = pageSizeName;
                    pageSize.UserCreated = idUser;
                    pageSize.DateCreated = DateTime.Now;
                    _context.AddAsync(pageSize);
                    await _context.SaveChangesAsync();
                    model.response = pageSize;
                }
                
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> DeletePageSize(int id)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var pageSize = await _context.TblPageSizes.Where(d => d.Id == id).FirstOrDefaultAsync();

                pageSize.IsDelete = true;
                await _context.SaveChangesAsync();
                model.response = pageSize;
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
