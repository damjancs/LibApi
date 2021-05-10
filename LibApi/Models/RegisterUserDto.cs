using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Models
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public DateTime BirthDate { get; set; }

        public int RoleId { get; set; } = 3;
    }
}
