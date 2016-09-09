namespace KamikazeChicken.Data.Migrations
{
    using Model.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KamikazeChicken.Data.KamikazeChickenDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KamikazeChicken.Data.KamikazeChickenDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            CreateProductCategorySample(context);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new KamikazeChickenDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new KamikazeChickenDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "kamikaze",
            //    Email = "vietnamthaotranvan@gmail.com",
            //    EmailConfirmed = true,
            //    //BirthDay = DateTime.Now,
            //    //FullName = "Technology Education"
            //};

            //manager.Create(user, "123456");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("vietnamthaotranvan@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(KamikazeChicken.Data.KamikazeChickenDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Chân sùi khủng",Alias="chan-sui",Status=true },
                 new ProductCategory() { Name="Chân tròn vảy thịt",Alias="chan-tron-vay-thit",Status=true },
                  new ProductCategory() { Name="Chân tròn vảy rồng",Alias="chan-tron-vay-rong",Status=true }
                  
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
    }
}