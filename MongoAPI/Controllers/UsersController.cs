using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cyclist.DataModel.Models;
using Cyclist.Services;

namespace MongoAPI.Controllers
{
    [RoutePrefix("Cyclist/Users")]
    public class UsersController : ApiController
    {
        private readonly IService<User> userService;

        public UsersController()
        {
            userService = new UserService();
        }

        [Route("User/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(String id)
        {
            var user = userService.Get(id);
            if (user != null)
                return Request.CreateResponse(HttpStatusCode.OK, user);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found for provided id.");
        }

        [Route("All")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var users = userService.GetAll();
            if (users.Any())
                return Request.CreateResponse(HttpStatusCode.OK, users);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No users found.");
        }

        [Route("NewUser")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            userService.Insert(user);
            return Request.CreateResponse(HttpStatusCode.OK, "User added successfuly");
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(String id)
        {
            userService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "User " + id + " deleted successfuly");
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]User user)
        {
            userService.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, "User " + user.UserId + " updated successfuly");
        }
    }
}

