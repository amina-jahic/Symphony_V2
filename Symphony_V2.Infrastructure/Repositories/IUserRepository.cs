using Symphony_V2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony_V2.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <returns>User list</returns>
        public Task<List<User>> GetUsersAsync();

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        public User CreateUser(User user);

        /// <summary>
        /// Remove user using user guid
        /// </summary>
        /// <param name="userGuid"></param>
        public bool RemoveUser(Guid userGuid);
    }
}
