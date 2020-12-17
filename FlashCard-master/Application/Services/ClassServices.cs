using System.Collections.Generic;
using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class ClassServices : IClassServices
    {
        private readonly IClassRepository _ClassRepository;

        public ClassServices(IClassRepository ClassRepository)
        {
            _ClassRepository = ClassRepository;
        }

        public bool ClassExists(int id)
        {
            var Class = _ClassRepository.GetBy(id);
            return Class != null;
        }

        public ClassDto GetBy(int id)
        {
            return _ClassRepository.GetBy(id).MappingDto();
        }

        public IEnumerable<ClassDto> GetAll()
        {
            return _ClassRepository.GetAll().MappingDto();
        }

        public int ClassCount(string id)
        {
            return _ClassRepository.Count(id);
        }

        public void CreateClass(ClassDto ClassDto)
        {
            var ClassToCreate = _ClassRepository.GetBy(ClassDto.ID);
            _ClassRepository.Add(ClassToCreate);
        }

        public void UpdateClass(ClassDto ClassDto)
        {
            var ClassToUpdate = _ClassRepository.GetBy(ClassDto.ID);
            _ClassRepository.Update(ClassToUpdate);
        }

        public void DeleteClass(int id)
        {
            var ClassToDelete = _ClassRepository.GetBy(id);
            _ClassRepository.Remove(ClassToDelete);
        }
    }
}