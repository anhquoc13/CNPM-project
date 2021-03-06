using System.Collections.Generic;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IClassServices
    {
        ClassDto GetBy(int id);
        IEnumerable<ClassDto> GetAll();
        int ClassCount(string id);
        void CreateClass(ClassDto classDto);
        void UpdateClass(ClassDto classDto);
        void DeleteClass(int id);
        bool ClassExists(int id);
    }
}