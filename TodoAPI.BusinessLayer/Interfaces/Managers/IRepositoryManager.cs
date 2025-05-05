using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.BusinessLayer.Interfaces.Repositories;

namespace TodoAPI.BusinessLayer.Interfaces.Managers
{
    public interface IRepositoryManager
    {
        /// <summary>
        /// Gets the repository for managing user entities.
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Gets the repository for managing category entities.
        /// </summary>
        ICategoryRepository Categories { get; }

        /// <summary>
        /// Gets the repository for managing todo items entities.
        /// </summary>
        ITodoRepository Todos { get; }

        /// <summary>
        /// Save changes async
        /// </summary>
        Task SaveAsync();
    }
}

