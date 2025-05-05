using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.BusinessLayer.DTOs
{
    public record TodoItemDto(
        Guid PublicId,
        string Title,
        bool IsCompleted,
        DateTime CreatedAt,
        Guid CategoryPublicId,
        Guid UserPublicId
    );
}
