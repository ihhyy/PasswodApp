using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Methods
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationContext context;

        public DataRepository()
        {
            context = new ApplicationContext();
        }

        public async Task DeleteDataByNameAsync(string userName, string name)
        {
            var userId = GetUserIdByName(userName);
            var data = await context.Datas.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if(data != null)
            {
                context.Datas.Remove(data);
                context.SaveChanges();
            }
        }

        public async Task<List<Data>> GetAllDataByUserNameAsync(string userName)
        {
            var userId = GetUserIdByName(userName);

            if (userId != null)
            {
                return await context.Datas.Where(x => x.UserId == userId).ToListAsync();
            }

            return null;
        }

        public async Task<Data> GetDataByNameAsync(string userName, string dataName)
        {
            int userId = GetUserIdByName(userName);
            var data = await context.Datas.Where(x => x.UserId == userId && x.Name == dataName).FirstAsync();
            if(data != null)
            {
                return data;
            }

            return null;
        }

        public async Task SetNewData(Data data, string userName)
        {
            if (context.Users.Any(x => x.Datas.Any(y => y.Name == data.Name)))
            {
                throw new Exception();
            }

            context.Datas.Add(data);
            await context.SaveChangesAsync();
        }

        public async Task UpdateDataByNameAsync(string userName, string dataName, Data data)
        {
            int userId = GetUserIdByName(userName);
            var dateToUpdate = await context.Datas.Where(x => x.UserId == userId && x.Name == dataName).FirstOrDefaultAsync();
            if(dateToUpdate != null)
            {
                context.Entry(dateToUpdate).State = EntityState.Modified;
                dateToUpdate.Status = data.Status;
                dateToUpdate.DataValue = data.DataValue;
                dateToUpdate.Name = data.Name;

                context.SaveChanges();
            }
        }

        private int GetUserIdByName(string userName)
        {
            return context.Users.Where(x => x.UserName == userName).FirstOrDefault().UserId;
        }
    }
}
