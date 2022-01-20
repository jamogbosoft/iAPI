using iAPI.Models;
using System.Linq;
using System.Web.Http;

namespace iAPI.Controllers
{
    [Authorize]
    [Route("api/UserProfile")]
    public class UserProfileController : ApiController
    {
        //Get api/UserProfile
        public string Get(string userName)
        {
            using (var context = new UserProfileDBContext())
            {
                var query = context.Users.FirstOrDefault(s => s.UserName == userName);
                return query == null ? "" : query.ProfileImage;

            }
        }

        //Post api/UserProfile
        public IHttpActionResult Post([FromBody] UserProfileModel UserProfile)
        {
            using (var db = new UserProfileDBContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserName == UserProfile.UserName);
                if (result!=null)
                {
                    result.ProfileImage = UserProfile.ProfileImage;
                    db.SaveChanges();
                }              

                return Ok(); // return 200 success code
            }
        }
    }
}
