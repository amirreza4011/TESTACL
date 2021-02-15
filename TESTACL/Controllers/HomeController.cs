using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TESTACL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        Rayavaran.Business.ACL a = new Rayavaran.Business.ACL();
        [HttpGet]
        public IActionResult test()
        
        {
            a.ACLOnMessageEvent += A_ACLOnMessageEvent;
            a.Initialize("CPOE", "1.0.0.0", "Password=SamsunG;Persist Security Info=True;User ID=Developer;Initial Catalog=ADT_RW97;Data Source=DENA");
            Rayavaran.BusinessObjects.AclUser o = new Rayavaran.BusinessObjects.AclUser();
            o.UserName = "rw";
            o.Password = "1235";
            var v=  a.IsAuthenticate(o);
            Rayavaran.BusinessObjects.AclUser o1 = new Rayavaran.BusinessObjects.AclUser();
            o1.UserName = "rw2";
            o1.Password = "1234";
            a.ChangePassword(o1,"1235");
            
            return Ok();
        }

        private void A_ACLOnMessageEvent(string messageText, Rayavaran.Common.eMessageType messageType)
        {
            throw new NotImplementedException();
        }
    }
}
