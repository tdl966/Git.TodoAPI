using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.Common.Models.Todo
{
    public class TodoItemModel
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;
    }
}
