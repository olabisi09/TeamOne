using CyberProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Interfaces
{
    public interface ISalary
    {
        Task<IEnumerable<Salary>> GetAll();
        void Add(Salary salary);
        Task<bool> AddAsync(Salary salary);
        Task<bool> Update(Salary salary);
        Task<Salary> GetById(int Id);
        Task<bool> Delete(int Id);
    }
}
