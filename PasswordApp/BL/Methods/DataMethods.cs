using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using DAL.Models;

namespace BL.Methods
{
    public class DataMethods : IDataMethods
    {
        private IDataRepository dataRepository;
        private IUserRepository userRepository;

        public DataMethods(IDataRepository _dataRepository, IUserRepository _userRepository)
        {
            dataRepository = _dataRepository;
            userRepository = _userRepository;
        }

        public async Task<List<Data>> GetAllUserDataByNameAsync(string userName)
        {
            return await dataRepository.GetAllDataByUserNameAsync(userName);
        }

        public async Task SetNewData(DataDto dataDto, string userName)
        {
            Data data = new();
            data.Name = dataDto.Name;
            data.DataValue = dataDto.Password;
            data.UserId = userRepository.GetUserByNameAsync(userName).Result.UserId;

            await dataRepository.SetNewData(data, userName);
        }

        public async Task UpdateDataByName(string userName, string dataName, DataDto newData)
        {
            Data data = new();
            data.Name = newData.Name;
            data.DataValue = newData.Password;
            await dataRepository.UpdateDataByNameAsync(userName, dataName, data);
        }

        public async Task DeleteDataByNameAsync(string dataName, string userName)
        {
            await dataRepository.DeleteDataByNameAsync(userName, dataName);
        }

        public async Task<Data> GetDataByNameAsync(string userName, string dataName)
        {
            return await dataRepository.GetDataByNameAsync(userName, dataName);
        }
    }
}
