using HCMUT_SSPS.ViewModels.ResultView;

namespace HCMUT_SSPS.Interfaces
{
    public interface IFileTypeRepository
    {
        public Task<ResultViewModel> GetFileTypes(string? keyword = "", int pageNumber = 1, int per_page = 6);
        public Task<ResultViewModel> CreateFileType(string typeName);
        public Task<ResultViewModel> UpdateFileType(Guid id, string typeName);
        public Task<ResultViewModel> DeleteFileType(Guid id);
    }
}
