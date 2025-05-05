using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.DataLayer.Entities
{
    public class UserEntity
    {
        public long UserId { get; set; }
        public Guid UserPublicId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }


        public List<TodoItemEntity> TodoItems { get; set; } = new();
    }
}
