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
    }
}
