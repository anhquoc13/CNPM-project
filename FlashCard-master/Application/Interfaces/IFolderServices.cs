using System.Collections.Generic;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IFolderServices
    {
        FolderDto GetBy(int id);
        IEnumerable<FolderDto> GetAll();
        void CreateFolder(FolderDto folderDto);
        void UpdateFolder(FolderDto folderDto);
        void DeleteFolder(int id);
        bool FolderExists(int id);
    }
}