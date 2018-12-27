using AP.Service.Helper;
using System.Web.Routing;

namespace ESunBank.Controllers
{
    public class BaseController : System.Web.Mvc.Controller
    {

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            GetUserNameAndUnit();
        }
        public void GetUserNameAndUnit ()
        {
            var user = UserInfoHelper.GetUserInfo();
            ViewBag.Name = user.UserName;
            ViewBag.Unit = user.Unit;
        }
    }
}