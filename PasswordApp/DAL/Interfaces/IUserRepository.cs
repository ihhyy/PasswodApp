using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        void SetUserAsync(User user);
        Task<User> GetUserByNameAsync(string userName);
    }
}
