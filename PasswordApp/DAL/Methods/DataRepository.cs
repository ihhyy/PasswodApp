using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Methods
{
    public class DataRepository : IDataRepository
    {
        public async void DeleteDataByNameAsync(int userId, string name)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var data = context.Datas.Where(x => x.UserId == userId && x.Name == name).FirstOrDefault();
                if(data != null)
                {
                    context.Datas.Remove(data);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Data>?> GetAllDataByUserIdAsync(int userId)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var datas = await context.Datas.Where(x => x.UserId == userId).ToListAsync();

                if (datas != null)
                {
                    return datas;
                }
                
                return null;
            }
        }

        public async Task<Data?> GetDataByNameAsync(int userId, string name)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var data = await context.Datas.Where(x => x.UserId == userId && x.Name == name).FirstAsync();
                if(data != null)
                {
                    return data;
                }

                return null;
            }
        }

        public async void SetNewData(Data data)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                if(context.Datas.Any(x => x.Name == data.Name))
                {
                    throw new Exception();
                }

                context.Datas.Add(data);
                await context.SaveChangesAsync();
            }
        }

        public async void UpdateDataByNameAsync(int userId, string name, Data data)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var dateToUpdate = context.Datas.Where(x => x.UserId == userId && x.Name == name).FirstOrDefault();
                if(dateToUpdate != null)
                {
                    context.Entry(dateToUpdate).State = EntityState.Modified;
                    dateToUpdate.Status = data.Status;
                    dateToUpdate.Password = data.Password;
                    dateToUpdate.Name = dateToUpdate.Name;
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
