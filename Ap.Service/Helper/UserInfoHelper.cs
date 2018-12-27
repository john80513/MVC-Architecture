using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace AP.Service.Helper
{
    public static class UserInfoHelper
    {
        public class userInfo
        {
            public string UserID { get; set; }
            public string UserName { get; set; }

            public int GroupId { get; set; }
            public int Level { get; set; }
            public string Unit { get; set; }
        }

        public static userInfo GetUserInfo()
        {
            userInfo uInfo = new userInfo();

            try
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

                // Get the claims values
                uInfo.UserName = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                uInfo.UserID = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
                uInfo.GroupId = int.Parse(identity.Claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault());
                uInfo.Level = int.Parse(identity.Claims.Where(c => c.Type == ClaimTypes.Version).Select(c => c.Value).SingleOrDefault());
                uInfo.Unit = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
            }
            catch
            {
            }

            return uInfo;
        }
    }
}
