using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.Account
{
    public class RegisterDTO
    {
        [Required]
        public string? Nome { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? PalavraPasse { get; set; }
    }
}