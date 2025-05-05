using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.BusinessLayer.DTOs
{
    public record UserDto(Guid PublicId, string Username, string Email);
}
