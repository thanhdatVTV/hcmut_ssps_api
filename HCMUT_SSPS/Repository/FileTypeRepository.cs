using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HCMUT_SSPS.Repository
{
    public class FileTypeRepository : IFileTypeRepository
    {
        private readonly HcmutSspsContext _context;

        public FileTypeRepository(HcmutSspsContext context) {
            _context = context;
        }

        

        public async Task<ResultViewModel> GetFileTypes(string? keyword = "", int page = 1, int per_page = 6)
        {
            ResultViewModel model = new ResultViewModel();

            try
            {
                FileTypeResponseViewModel listFileTypeViewModel = new FileTypeResponseViewModel();

                var queryCount = await _context.TblFileTypes.ToListAsync();
                listFileTypeViewModel.Total = queryCount.Count();

                var query = await _context.TblFileTypes.Skip(per_page * (page - 1)).Take(per_page).ToListAsync();
                //query = query.Skip(per_page * (page - 1)).Take(per_page).ToLis;

                var results = query.Select(u => new ResponseFileTypeModel
                {
                    Id = u.Id,
                    TypeName = u.TypeName
                }).ToList();

                listFileTypeViewModel.Page = page;
                listFileTypeViewModel.PerPage = per_page;
                listFileTypeViewModel.TotalPages = listFileTypeViewModel.Total / per_page;

                listFileTypeViewModel.FileTypes = results;

                model.status = 1;
                model.message = "Get list file type success!";
                model.response = listFileTypeViewModel;
            }
            catch (Exception ex)
            {
                model.status = -1;
                model.message = "Service không hoạt động " + ex.Message.ToString();
            }

            return model;
        }

        public async Task<ResultViewModel> UpdateFileType(Guid id, string typeName)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var fileType = await _context.TblFileTypes.Where(d => d.Id == id).FirstOrDefaultAsync();

                fileType.TypeName = typeName;
                fileType.UserUpdated = id;
                fileType.DateUpdated = DateTime.Now;
                await _context.SaveChangesAsync();
                model.response = fileType;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> CreateFileType(string typeName)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                Guid id = Guid.NewGuid();
                var fileType = new TblFileType();
                fileType.Id = id;
                fileType.TypeName = typeName;
                fileType.UserCreated = id;
                fileType.DateCreated = DateTime.Now;
                _context.AddAsync(fileType);
                await _context.SaveChangesAsync();
                model.response = fileType;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> DeleteFileType(Guid id)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var fileType = await _context.TblFileTypes.Where(d => d.Id == id).FirstOrDefaultAsync();

                fileType.IsDelete = true;
                await _context.SaveChangesAsync();
                model.response = fileType;
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
