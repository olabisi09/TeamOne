using CyberProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Interfaces
{
    public interface IGrade
    {
        void Add(Grade grade);
        Task<bool> AddAsync(Grade grade);
        Task<bool> Update(Grade grade, int Id);
        Task<IEnumerable<Grade>> GetAll();
        Task<Grade> GetById(int Id);
        Task<bool> Delete(int Id);
    }
}
