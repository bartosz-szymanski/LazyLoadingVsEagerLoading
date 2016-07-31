using System;
using System.ComponentModel.DataAnnotations;

namespace LazyVsEager.Models
{
    public class Blog : BaseRow
    {
        //Foreign Key
        public long AuthorId { get; set; }
        [Required]
        public string Address { get; set; }

        public DateTime CreationDate { get; set; }

        //Navigation Property
        public virtual Author Author { get; set; } 

    }
}