
using global::Symphony_V2.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Symphony_V2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony_V2.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly Context _context;


        public UserRepository(Context context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                //TODO
                //Log an exception
                return null;
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                //TODO
                //Log an exception
            }

            return new List<User>();
        }

        public bool RemoveUser(Guid userGuid)
        {
            try
            {
                var user = _context.Users.Find(userGuid);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //TODO
                //Log an exception
                return false;
            }
        }
    }
}