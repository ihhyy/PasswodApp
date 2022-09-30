using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Methods
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserByNameAsync(string userName)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return await context.Users.Where(x => x.UserName == userName).FirstAsync();
            }
        }

        public async void SetUserAsync(User user)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (context.Users.Any(x => x.UserName == user.UserName))
                {
                    throw new Exception();
                }

                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
