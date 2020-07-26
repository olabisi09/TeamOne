using CyberProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Interfaces
{
    public interface ISalary
    {
        float GetNetSalary(Salary s);
        Task<IEnumerable<Salary>> GetAll();
    }
}
