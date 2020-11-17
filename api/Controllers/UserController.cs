using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRApp.API.Models;
using System.Reflection;
using Microsoft.AspNetCore.Cors;
using System.Collections;

namespace HRApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        List<User> Users { get; set; }

       public UserController()
        {
            var userList = new UserList();
            Users = userList.users;
        }

        // GET api/user
        [HttpGet("{id}")]
        public ActionResult<UserInfo> GetUserInfo(Guid id)
        {
            var userFound = Users.SingleOrDefault( x => x.Id == id );
            if (userFound != null)
            {
                return Ok(new { user = userFound.UserInfo }); 
            }
            return BadRequest(new {message = "ID does not exist"});
            
        }

        // PUT api/user/:id
        [HttpPut("{id}")]
        public ActionResult<UserInfo> EditUserInfo(Guid id, [FromBody] UserInfo info)
        {
            var userFound = Users.SingleOrDefault( x => x.Id == id );
            if (userFound != null)
            {
                foreach (var item in typeof (UserInfo).GetProperties().Where(p => (p.GetValue(info) != null)))
                {
                    PropertyInfo property = typeof (UserInfo).GetProperty(item.Name);
                    if (!(property.PropertyType == typeof (DateTime) && property.GetValue(info).ToString() == new DateTime().ToString()))
                    {
                        property.SetValue(userFound.UserInfo, property.GetValue(info));
                    }
                  
                }
                return Ok(new {user = userFound.UserInfo}); 
            }
            return BadRequest(new {message = "ID does not exist"});
        }
    

        // POST api/user/
        [HttpPost]
        public ActionResult<User> AddUser([FromBody] UserInfo info)
        {
            Guid id = Guid.NewGuid();
            string username = info.GenerateUsername();
            Login login = new Login { Email = username, Password = "ABC" };
            User newUser = new User (login, info, id);
            Users.Add(newUser);

            return Ok(new {user = newUser}); 
        }


        // GET api/user
        [HttpGet("all")]
        public ActionResult<List<UserInfo>> GetAllUsers()
        {
            ArrayList allUsers = new ArrayList();
            foreach (User user in Users)
            {
                allUsers.Add(user.UserInfo);
            }
            return Ok(new {users = allUsers});
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteUser(Guid id)
        {
            var userFound = Users.SingleOrDefault( x => x.Id == id );
            if (userFound != null)
            {
                Users.Remove(userFound);
               
                return Ok(new { message = "User has been deleted successfully" }); 
            }
            return BadRequest(new {message = "ID does not exist"});
            
        }
    
    }
}