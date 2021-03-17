using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;

namespace Api.DataService
{
    public class Seed
    {
        public static async Task UserData(DataContext context)
        {
            if(context.Users.Any()) return;

            var users = new List<User>
            {
                new User 
                {
                    Name = "Suzuki",
                    Age = 20,
                    Height = 172.1,
                    Weight = 60.4
                },
                new User
                {
                    Name = "Tanaka",
                    Age = 30,
                    Height = 182.5,
                    Weight = 72.4
                },
                new User
                {
                    Name = "Yamada",
                    Age = 25,
                    Height = 160.5,
                    Weight = 48.9
                },
                new User
                {
                    Name = "Sato",
                    Age = 22,
                    Height = 175.6,
                    Weight = 65.2
                }
            };
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}