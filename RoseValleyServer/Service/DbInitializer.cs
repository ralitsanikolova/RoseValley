using CommonFiles;
using DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoseValleyServer.Service.IService;

namespace RoseValleyServer.Service
{
    public class DbInitializer : IDbInitilizer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            try
            { 
            //{
            //    if (_db.Database.GetPendingMigrations().Count() > 0)
            //    {
            //        _db.Database.Migrate();
            //    }
            //    if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            //    {
            //        _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            //        _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
            //    }
            //    else
            //    {
            //        return;
            //    }

            //    IdentityUser user = new()
            //    {
            //        UserName = "admin123@gmail.com",
            //        Email = "admin123@gmail.com",
            //        EmailConfirmed = true
            //    };

            //    _userManager.CreateAsync(user, "Admin_123").GetAwaiter().GetResult();
            //    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();




                
                    if (_db.Database.GetPendingMigrations().Count() > 0)
                    {
                        _db.Database.Migrate();
                    }


                    if (_db.Roles.Any(x => x.Name == SD.Role_Admin))
                        return;
                    //check if it needs brackedts  

                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();

                    _userManager.CreateAsync(new IdentityUser
                    {
                        UserName = "admin123@gmail.com",
                        Email = "admin123@gmail.com",
                        EmailConfirmed = true
                    }, "Admin_123").GetAwaiter().GetResult();

                    IdentityUser user = _db.Users.FirstOrDefault(u => u.Email == "admin123@gmail.com");
                    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

                    //IdentityUser user = new()
                    //{
                    //    UserName = "rosevalley@gmail.com",
                    //    Email = "rosevalley@gmail.com",
                    //    EmailConfirmed = true,

                    //};

                    //_userManager.CreateAsync(user, "rosevalley_123").GetAwaiter().GetResult();
                    //_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();



                }
            catch (Exception ex)
            {

            }

        }
    }
}
