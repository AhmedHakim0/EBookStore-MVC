using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EBookStore
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [Length(4,30,ErrorMessage ="Name must be between 4-30 char")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1:100")]
        public int DisplayOrder { get; set; }
    }
}
