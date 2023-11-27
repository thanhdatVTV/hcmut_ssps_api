using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.ViewModels.ResultView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HCMUT_SSPS.Repository
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly HcmutSspsContext _context;

        public PrinterRepository(HcmutSspsContext context) {
            _context = context;
        }

        

        public async Task<ResultViewModel> GetPrinters(string? keyword = "", int page = 1, int per_page = 6)
        {
            ResultViewModel model = new ResultViewModel();

            try
            {
                PrinterResponseViewModel listPrinterViewModel = new PrinterResponseViewModel();


                var query = await _context.TblPrinters.ToListAsync();

                var results = query.Select(u => new ResponsePrinterModel
                {
                    Id = u.Id,
                    Brand = u.Brand,
                    PrinterModel = u.PrinterModel,
                    Description = u.Description
                }).ToList();

                listPrinterViewModel.Total = query.Count();
                listPrinterViewModel.Page = page;
                listPrinterViewModel.PerPage = per_page;
                listPrinterViewModel.TotalPages = listPrinterViewModel.Total / per_page;

                listPrinterViewModel.Printers = results;

                model.status = 1;
                model.message = "Get list printer success!";
                model.response = listPrinterViewModel;
            }
            catch (Exception ex)
            {
                model.status = -1;
                model.message = "Service không hoạt động " + ex.Message.ToString();
            }

            return model;
        }

        public async Task<ResultViewModel> UpdatePrinter(Guid id, string brand, string printerModel, string description)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var printer = await _context.TblPrinters.Where(d => d.Id == id).FirstOrDefaultAsync();

                printer.Brand = brand;
                printer.PrinterModel = printerModel;
                printer.Description = description;
                printer.UserUpdated = id;
                printer.DateUpdated = DateTime.Now;
                await _context.SaveChangesAsync();
                model.response = printer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> CreatePrinter(string brand, string printerModel, string description)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                Guid id = Guid.NewGuid();
                var printer = new TblPrinter();
                printer.Id = id;
                printer.Brand = brand;
                printer.PrinterModel = printerModel;
                printer.Description = description;
                printer.UserCreated = id;
                printer.DateCreated = DateTime.Now;
                _context.AddAsync(printer);
                await _context.SaveChangesAsync();
                model.response = printer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> DeletePrinter(Guid id)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var printer = await _context.TblPrinters.Where(d => d.Id == id).FirstOrDefaultAsync();

                printer.IsDelete = true;
                await _context.SaveChangesAsync();
                model.response = printer;
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
