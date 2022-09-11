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
        void SetNewData(Data data);
        Task<List<Data>> GetAllDataByUserIdAsync(int userId);
        Task<Data> GetDataByNameAsync(int userId, string name);
        void DeleteDataByNameAsync(int userId, string name);
        void UpdateDataByNameAsync(int userId, string name, Data data);
    }
}
