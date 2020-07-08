using System;
using System.ComponentModel.DataAnnotations;

namespace PostgresEFCore.Models
{
    public class Enterprise
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long Nit { get; set; }
        [Required]
        public long GIn { get; set; }
    }
}