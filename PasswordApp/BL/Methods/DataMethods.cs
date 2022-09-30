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
            data.Name = dataDto.SecretName;

            if(dataDto.Status == DAL.Statuses.Auto & dataDto.SecretLength != null)
            {
                data.DataValue = GenerateNewSecret((int)dataDto.SecretLength);
            }

            else
            {
                data.DataValue = dataDto.SecretValue;
            }

            data.Status = dataDto.Status;

            data.UserId = userRepository.GetUserByNameAsync(userName).Result.UserId;

            await dataRepository.SetNewData(data, userName);
        }

        public async Task UpdateDataByName(string userName, string dataName, DataDto newData)
        {
            Data data = new();
            data.Name = newData.SecretName;
            data.DataValue = newData.SecretValue;
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

        private string GenerateNewSecret(int length)
        {
            Random generator = new();

            string secret = string.Empty;

            for(int i = 0; i < length; i++)
            {
                var random = generator.Next(2);

                if(random == 0)
                {
                    secret += GenerateRandomNumber();
                }

                else
                {
                    secret += GenerateRandomLetter();
                }
            }

            return secret;
        }

        private char GenerateRandomLetter()
        {
            String str = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();

            if(random.Next(2) == 0)
            {
                return Char.ToUpper(str[random.Next(str.Length)]);
            }

            return str[random.Next(str.Length)];
        }

        private string GenerateRandomNumber()
        {
            return new Random().Next(10).ToString();
        }
    }
}
