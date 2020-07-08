using System;
using System.ComponentModel.DataAnnotations;

namespace PostgresEFCore.Models
{
    public class Code
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual  Enterprise Owner { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}