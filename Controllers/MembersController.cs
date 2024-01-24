using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedOakAPI.Db;
using RedOakAPI.Models;
using RedOakAPI.ViewModel;
using SqlKata.Execution;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedOakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        // GET: api/<MembersController>
        [HttpGet]
        public List<Member> Get([FromQuery] string? status)
        {
            var db = DbManager.Connect();

            var query = db.Query("Members");

            if (status != null && status != "")
            {
                query.Where("Status", "LIKE", status);
            }

            List<Member> members = query.Get<Member>().ToList();

            return members;
        }

        // POST api/<MembersController>
        [HttpPost]
        public async Task<Member> Post(MembersViewModel member)
        {
            var db = DbManager.Connect();

            Member memberData = new Member
            {
                Id = Guid.NewGuid().ToString(),
                First_Name = member.First_Name,
                Last_Name = member.Last_Name,
                Middle_Name = member.Middle_Name,
                Age = member.Age,
                Birthdate = member.Birthdate,
                Sex = member.Sex,
                Status = member.Status
            };


            int date = await db.Query("Members").InsertAsync(memberData);

            return memberData;
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public async Task<string> PutAsync(string id, MembersViewModel member)
        {
            var db = DbManager.Connect();

            int checkIfExist = db.Query("Members").Where("Id", "LIKE", id).Get().ToList().Count();

            if (checkIfExist > 0)
            {

                int date = await db.Query("Members").Where("Id", "LIKE", id).UpdateAsync(member);

                return id;
            }
            else {
                return "";
            }
            
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            var db = DbManager.Connect();

            int checkIfExist = db.Query("Members").Where("Id", "LIKE", id).Get().ToList().Count();

            if (checkIfExist > 0)
            {

                int date = await db.Query("Members").Where("Id", "LIKE", id).DeleteAsync();

                return id;
            }
            else
            {
                return "";
            }
        }
    }
}
