using DAL;
using DAL.Interfaces;
using DAL.Methods;
using DAL.Models;

namespace ConsoleApp
{
    class ConsoleAppView
    {
        static async Task Main(string[] args)
        {
            //using (ApplicationContext context = new ApplicationContext())
            //{
            //    User user = new() { Name = "q", Password = "w", QuantityOfData = 2 };
            //    Data _data = new() { Name = "e", Status = (Statuses)1, Password = "r", User = user };

            //    context.Datas.Add(_data);
            //    context.Users.Add(user);

            //    context.SaveChanges();
            //    Console.WriteLine("sucess");
            //}

            User user = new() { Name = "q", Password = "w", QuantityOfData = 2 };
            Data _data = new() { Name = "e", Status = (Statuses)1, Password = "r", UserId = 1 };
            Data _data_update = new() { Name = "edit", Status = (Statuses)2, Password = "r_update", UserId = 12345 };


            DataRepository repository = new();

            try
            {
                //repository.SetNewData(_data);

                //repository.UpdateDataByNameAsync(1, _data.Name, _data_update);

                //repository.DeleteDataByNameAsync(1, "e");

                //var q = await repository.GetDataByNameAsync(1, _data.Name);
                //Console.WriteLine(q.UserId);

                //repository.SetNewData(_data);
                //var w = await repository.GetAllDataByUserIdAsync(1);
                //foreach (var item in w)
                //{
                //    Console.WriteLine(item.Status);
                //}

                Console.WriteLine("sucess");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
