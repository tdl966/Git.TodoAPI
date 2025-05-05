
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Common.Models.Todo
{
    public class CreateTodoItemModel : TodoItemModel
    {
        [Required]
        public Guid CategoryPublicId { get; set; }

        [Required]
        public Guid UserPublicId { get; set; }
    }
}
