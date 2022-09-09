using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDataRepository
    {
        Task<Data> GetAllDataByUserIdAsync(int id);
        Task<Data> GetDataNameAsync(int id, string name);
        Task<Data> DeleteDataNameAsync(int id, string name);
        Task<Data> UpdateDataNameAsync(int id, Data data);
    }
}
