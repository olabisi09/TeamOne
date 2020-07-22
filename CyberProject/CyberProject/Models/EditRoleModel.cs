using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Models
{
    public class EditRoleModel
    {
        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
