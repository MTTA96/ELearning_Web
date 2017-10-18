using System.ComponentModel.DataAnnotations;

namespace ELearning.Models
{
    public class Buoi
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}