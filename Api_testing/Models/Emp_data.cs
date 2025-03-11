using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api_testing.Models
{
    public class Emp_data
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
    }

}