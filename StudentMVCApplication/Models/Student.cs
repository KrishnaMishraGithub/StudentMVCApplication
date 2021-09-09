using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StudentMVCApplication.Models
{
    public partial class Student
    {
        [Key]
        public int Sid { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        
       // public string SearchStudent { get; set; }


    }
}
