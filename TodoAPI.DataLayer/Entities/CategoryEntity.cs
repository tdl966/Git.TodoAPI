using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.DataLayer.Entities
{
    public class CategoryEntity
    {
        public long CategoryId { get; set; }
        public Guid CategoryPublicId { get; set; }
        public string Name { get; set; }


        public List<TodoItemEntity> TodoItems { get; set; } = new();
    }
}
