using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBookStore.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength =4, ErrorMessage = "Name must be between 4-30 char")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public String ISBN {get; set; }
        [Required]
        public string Author { get; set; }

        [Required] 
        [Display(Name = "List Price")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1-1000")]
        public  double ListPrice { get; set; }
        [Required]
        [Display (Name = "Price for 1-50")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1-1000")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1-1000")]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1-1000")]
        public double Price100 { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string ImageURL { get; set; }

    }
}
