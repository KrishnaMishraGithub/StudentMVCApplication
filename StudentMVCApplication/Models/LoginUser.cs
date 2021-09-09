using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApplication.Models
{
    
    public class LoginUser
    {
        

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        
        
    }
}
