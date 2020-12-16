using System.Collections.Generic;
using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class FolderServices : IFolderServices
    {
        private readonly IFolderRepository _folderRepository;

        public FolderServices(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public bool FolderExists(int id)
        {
            var folder = _folderRepository.GetBy(id);
            return folder != null;
        }

        public FolderDto GetBy(int id)
        {
            return _folderRepository.GetBy(id).MappingDto();
        }

        public IEnumerable<FolderDto> GetAll()
        {
            return _folderRepository.GetAll().MappingDto();
        }

        public void CreateFolder(FolderDto FolderDto)
        {
            var folderToCreate = _folderRepository.GetBy(FolderDto.ID);
            _folderRepository.Add(folderToCreate);
        }

        public void UpdateFolder(FolderDto FolderDto)
        {
            var folderToUpdate = _folderRepository.GetBy(FolderDto.ID);
            _folderRepository.Update(folderToUpdate);
        }

        public void DeleteFolder(int id)
        {
            var folderToDelete = _folderRepository.GetBy(id);
            _folderRepository.Remove(folderToDelete);
        }
    }
}