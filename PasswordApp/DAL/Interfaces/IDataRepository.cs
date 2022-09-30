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
        Task SetNewData(Data data, string userName);
        Task<List<Data>> GetAllDataByUserNameAsync(string userName);
        Task<Data> GetDataByNameAsync(string userName, string dataName);
        Task DeleteDataByNameAsync(string userName, string name);
        Task UpdateDataByNameAsync(string userName, string dataName, Data data);
    }
}
