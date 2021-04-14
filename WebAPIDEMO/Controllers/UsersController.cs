using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDataAccess;

namespace WebAPIDEMO.Controllers
{
    public class UsersController : ApiController
    {
        //public IEnumerable<UsersDetail> Get()
        //{
        //    using (APIDBEntities entities = new APIDBEntities())
        //    {
        //        return entities.UsersDetails.ToList();
        //    }
        //}
        public UsersDetail Get(string email)
        {
            using (APIDBEntities entities = new APIDBEntities())
            {
                return entities.UsersDetails.FirstOrDefault(u => u.EmailID == email);
            }
        }
    }
}
