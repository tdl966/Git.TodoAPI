using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.Common.Models.Todo
{
    public class UpdateTodoItemModel : TodoItemModel
    {
        [Required]
        public bool IsCompleted { get; set; }
    }
}
