using System.ComponentModel.DataAnnotations;

namespace TradoGlobal.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Gender { get; set; }
        [Required]
        [StringLength(250)]
        public string Hobby { get; set; }
    }
}
