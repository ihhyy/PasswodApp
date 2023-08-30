using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUserMethods
    {
        User RegisterUser(UserLogin request);
        Task<string> LoginUserAsync(UserLogin request);
    }
}
