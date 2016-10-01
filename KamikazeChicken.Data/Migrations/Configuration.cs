namespace KamikazeChicken.Data.Migrations
{
    using Common;
    using Model.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
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
            CreateSlide(context);
            CreatePages(context);
            CreateContactDetail(context);
            // CreateFooter();
        }

        private void CreateUser(KamikazeChickenDbContext context)
        {
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

        private void CreateFooter(KamikazeChickenDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "";
            }
        }

        private void CreateSlide(KamikazeChickenDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag.jpg",
                        Content =@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                        <span class='on-get'>GET NOW</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag1.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class='on-get'>GET NOW</span>"}
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePages(KamikazeChickenDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                Page introduce = new Page()
                {
                    Name = "Giới thiệu",
                    Alias = "gioi-thieu",
                    Content = @"Trong cuộc tranh luận đối mặt lần đầu tiên vào đêm 26/9 tại Đại học Hofstra (New York), bà Clinton nhắc đến các phát ngôn của đối thủ Donald Trump với  một hoa hậu và công kích việc hạ thấp phẩm giá phụ nữ của ông Trump.
                                Chỉ vài giờ sau cuộc tranh luận,
                                bộ máy vận động tranh cử của đại diện đảng Dân chủ tung ra một đoạn video,
                                trong đó cựu hoa hậu Hoàn vũ Alicia Machado,39 tuổi,
                                kể lại 'cơn ác mộng' khủng khiếp sau khi đăng quang năm 1996 - thời điểm tỷ phú Trump nắm giữ nhiều cổ phần trong cuộc thi sắc đẹp này.",
                    Status = true
                };
                context.Pages.Add(introduce);
                context.SaveChanges();
            }
        }

        private void CreateContactDetail(KamikazeChickenDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new KamikazeChicken.Model.Models.ContactDetail()
                    {
                        Name = "Công ty Tư Vấn và Giải Pháp Kamikaze A.S",
                        Address = "C5/1 Nữ Dân Công",
                        Email = "kamikaze.analysis.solution@gmail.com",
                        Lat = 0.8322396,
                        Lng = 106.5280168,
                        Phone = "0986936609",
                        Website = "http://kamikazeas.com.vn",
                        Other = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }
    }
}