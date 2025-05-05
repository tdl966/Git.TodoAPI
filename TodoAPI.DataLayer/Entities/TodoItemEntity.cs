using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.DataLayer.Entities
{
    public class TodoItemEntity
    {
        public long TodoItemId { get; set; }
        public Guid TodoItemPublicId { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }


        public long UserId { get; set; }
        public UserEntity User { get; set; }

        public long CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
