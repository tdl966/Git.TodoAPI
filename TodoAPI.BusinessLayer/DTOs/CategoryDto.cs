using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.BusinessLayer.DTOs
{
    public record CategoryDto(Guid PublicId, string Name);
}
