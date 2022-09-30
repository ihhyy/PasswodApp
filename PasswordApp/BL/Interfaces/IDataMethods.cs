using BL.Models;
using DAL.Models;

namespace BL.Interfaces
{
    public interface IDataMethods
    {
        Task<List<Data>> GetAllUserDataByNameAsync(string userName);
        Task SetNewData(DataDto dataDto, string userName);
        Task UpdateDataByName(string userName, string dataName, DataDto newData);
        Task DeleteDataByNameAsync(string dataName, string userName);
        Task<Data> GetDataByNameAsync(string userName, string dataName);
    }
}
