using System.ComponentModel.DataAnnotations;

namespace LazyVsEager.Models
{
    public class Author : BaseRow
    {
        [Required]
        public string Name { get; set; }
    }
}