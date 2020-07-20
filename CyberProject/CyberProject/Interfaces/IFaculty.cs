using CyberProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Interfaces
{
    public interface IFaculty
    {
        void Add(Faculty faculty);
        Task<bool> AddAsync(Faculty faculty);
        Task<bool> Update(Faculty faculty);
        Task<IEnumerable<Faculty>> GetAll();
        Task<Faculty> GetById(int Id);
        Task<bool> Delete(int Id);
    }
}
