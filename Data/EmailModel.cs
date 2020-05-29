using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp11.Data
{
    public class EmailModel
    {
        [Required]
        public string Name { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
