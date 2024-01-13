using CoreAndFood.Entities;
using CoreAndFood.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            Context context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Context>();

            CategoryRepository cm = new CategoryRepository();
            FoodRepository foodRepository = new FoodRepository();
            
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!cm.TList().Any())
            {
                cm.TAdd(new Category { CategoryName = "Meyveler", CategoryDescription = "meyve", Status = true });
                cm.TAdd(new Category { CategoryName = "Sebzeler", CategoryDescription = "sebze", Status = true });
                cm.TAdd(new Category { CategoryName = "Bakliyat", CategoryDescription = "bakliyat", Status = true });
                cm.TAdd(new Category { CategoryName = "İçecekler", CategoryDescription = "içecek", Status = true });
                cm.TAdd(new Category { CategoryName = "Unlu Mamuller", CategoryDescription = "unlu mamuller", Status = true });
                cm.TAdd(new Category { CategoryName = "Meyve Suları", CategoryDescription = "meyve suları", Status = true });
            }

            if (!foodRepository.TList().Any())
            {
                foodRepository.TAdd(new Food { Name = "Portakal", Description = "portakal", Price =0.99 , ImageURL = "https://i.hizliresim.com/3j4i0sv.jpg", Stock = 120, CategoryID = 1 });
                foodRepository.TAdd(new Food { Name = "Domates", Description = "domates", Price = 1.25 , ImageURL = "https://i.hizliresim.com/9v1v09n.jpg", Stock = 500, CategoryID = 2 });
                foodRepository.TAdd(new Food { Name = "Kavun", Description = "kavun", Price = 1.92, ImageURL = "https://i.hizliresim.com/n5rrwnb.jpg", Stock = 500, CategoryID =  1});
                foodRepository.TAdd(new Food { Name = "Pirinç", Description = "pirinç", Price = 2.25, ImageURL = "https://i.hizliresim.com/3v5vl2h.jpg", Stock = 800, CategoryID = 3 });
                foodRepository.TAdd(new Food { Name = "Mısır", Description = "mısır", Price = 1.75, ImageURL = "https://i.hizliresim.com/ia0y4jk.jfif", Stock = 250, CategoryID =  3});
                foodRepository.TAdd(new Food { Name = "Vişne Suyu", Description = "vişne suyu", Price = 1.85 , ImageURL = "https://i.hizliresim.com/ow3z3bx.jpg", Stock = 140, CategoryID = 2 });
                foodRepository.TAdd(new Food { Name = "Havuç", Description = "havuç", Price = 1.99, ImageURL = "https://i.hizliresim.com/run314p.jpg", Stock = 200, CategoryID =  2});
                foodRepository.TAdd(new Food { Name = "Elma", Description = "elma", Price = 0.99, ImageURL = "https://i.hizliresim.com/oazn1oq.jpg", Stock = 250, CategoryID =  1});
                foodRepository.TAdd(new Food { Name = "Patates", Description = "patates", Price = 0.35, ImageURL = "https://i.hizliresim.com/gjwyt3y.jpg", Stock = 400, CategoryID = 2 });
            }

            if (!context.Admins.ToList().Any())
            {
                context.Admins.Add(new Admin { UserName = "admin1", Password = "123", AdminRole = "A" });
                context.Admins.Add(new Admin { UserName = "admin2", Password = "111", AdminRole = "A" });
                context.Admins.Add(new Admin { UserName = "admin3", Password = "456", AdminRole = "B" });
                context.Admins.Add(new Admin { UserName = "admin4", Password = "1234", AdminRole = "a" });
                context.SaveChanges();
            }
        }
    }
}
