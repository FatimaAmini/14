using Hw14_Fateme_amini.Extensions;
using Hw14_Fateme_amini.Models.Entities;
using Hw14_Fateme_amini.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hw14_Fateme_amini.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet(), ActionName("Create")]
        public IActionResult CreateUser()
        {
            return View(nameof(CreateUser));
        }

        [HttpPost(),ActionName("Create")]
        public IActionResult CreateUser(RegisterViewModel registerViewModel)
        {
             
            JSONReadWrite readWrite = new JSONReadWrite();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(readWrite.Read("User.json", "Data"));
            if(users is null)
            {
                users = new List<User>();
                string list = JsonConvert.SerializeObject(users);
                readWrite.Write("User.json", "Data", list);
                users = JsonConvert.DeserializeObject<List<User>>(readWrite.Read("User.json", "Data"));
            }

            int id=0;
            if (users.Count >= 1)
            {
                 id = users.OrderByDescending(x => x.Id).Select(x => x.Id).ToList().Max();
            }
            var user = new User
            {
                Id=(id+1),
                Birthday=registerViewModel.Birthday,
                CourseCode=registerViewModel.CourseCode,
                FirstName=registerViewModel.FirstName,
                LastName=registerViewModel.LastName,
                Gender=registerViewModel.Gender,
                PhoneNumber=registerViewModel.PhoneNumber,
            };
            users.Add(user);

            string jSONString = JsonConvert.SerializeObject(users);
            readWrite.Write("User.json", "Data", jSONString);

            return Redirect("/");
        }

    }
}
