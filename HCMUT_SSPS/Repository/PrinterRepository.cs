using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.EntityFrameworkCore;

namespace HCMUT_SSPS.Repositories
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly HcmutSspsContext _dbContext;

        public PrinterRepository(HcmutSspsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PrinterRepositoryViewModel> GetPrinters(string? keyword, int pageNumber = 1, int per_page = 6)
        {
            var result = new PrinterRepositoryViewModel();

            var query = _dbContext.TblPrinters.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Model.Contains(keyword) || p.Description.Contains(keyword));
            }

            result.Total = query.Count();
            result.TotalPages = (int)Math.Ceiling(result.Total / (double)per_page);

            var printers = await query
                .OrderBy(p => p.Model)
                .Skip((pageNumber - 1) * per_page)
                .Take(per_page)
                .Select(p => new ResponsePrinterModel
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    Description = p.Description,
                    LocationId = p.LocationId ?? 0,
                    Status = p.Status ?? 0,
                    IsDelete = p.IsDelete ?? false,
                    UserCreated = p.UserCreated,
                    DataCreated = p.DataCreated,
                    UserUpdated = p.UserUpdated,
                    DateUpdated = p.DateUpdated
                })
                .ToListAsync();

            result.Printers = printers;
            result.Page = pageNumber;
            result.PerPage = per_page;

            return result;
        }

        public async Task<ResultViewModel> AddPrinter(string brand, string model, string description, int locationId, int status)
        {
            var newPrinter = new TblPrinter
            {
                Id = Guid.NewGuid(),
                Brand = brand,
                Model = model,
                Description = description,
                LocationId = locationId,
                Status = status,
                DataCreated = DateTime.UtcNow
                //Thêm các giá trị còn lại tùy ý
            };

            _dbContext.TblPrinters.Add(newPrinter);
            await _dbContext.SaveChangesAsync();

            return new ResultViewModel { message = "Máy in được thêm mới thành công." };
        }

        public async Task<ResultViewModel> UpdatePrinter(Guid id, string brand, string model, string description, int locationId, int status)
        {
            var printerToUpdate = await _dbContext.TblPrinters.FindAsync(id);

            if (printerToUpdate == null)
            {
                return new ResultViewModel { message = "Không tìm thấy máy in." };
            }

            printerToUpdate.Brand = brand;
            printerToUpdate.Model = model;
            printerToUpdate.Description = description;
            printerToUpdate.LocationId = locationId;
            printerToUpdate.Status = status;

            // Cập nhật thông tin còn lại nếu có

            await _dbContext.SaveChangesAsync();

            return new ResultViewModel { message = "Máy in được cập nhật thành công." };
        }

        public async Task<ResultViewModel> DeletePrinter(Guid id)
        {
            var printerToDelete = await _dbContext.TblPrinters.FindAsync(id);

            if (printerToDelete == null)
            {
                return new ResultViewModel { message = "Không tìm thấy máy in." };
            }

            _dbContext.TblPrinters.Remove(printerToDelete);
            await _dbContext.SaveChangesAsync();

            return new ResultViewModel { message = "Máy in được xóa thành công." };
        }
    }
}
