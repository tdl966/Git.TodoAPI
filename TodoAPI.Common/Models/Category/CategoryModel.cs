using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Common.Models.Category
{
    public class CategoryModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
    }
}
