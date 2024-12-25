using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TokenGenerate.EF.Tables
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TokenNumber { get; set; }

        [Required]
        public string VisaType { get; set; }

        [Required]
        public DateTime GeneratedDate { get; set; }
    }
}