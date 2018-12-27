using AP.Models;
using AP.Models.Interface;
using AP.Models.Repository;
using AP.Service.ViewModels.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AP.Web.Infrastructure.ActionFilter
{
    public class CustomizeAuth
    {
        public class CustomizeAuthAttribute : AuthorizeAttribute
        {
            /// <summary>
            /// ControllerName_ActionName
            /// </summary>
            public string menuName { get; set; }

            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                try
                {
                    if (httpContext == null)
                        throw new ArgumentNullException("httpContext");

                    // 檢查登入
                    if (!httpContext.User.Identity.IsAuthenticated)
                        return false;

                    // 取得使用者的角色 
                    var userIdentity = (ClaimsIdentity)httpContext.User.Identity;
                    var claims = userIdentity.Claims;

                    string employeeID = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
                    int groupId = int.Parse(claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault());

                    // 取得角色可使用功能
                    List<string> apList = this.GetAPList(employeeID, groupId);

                    // 比對是否有符合之功能
                    return apList.Any(x => x == menuName);
                }
                catch
                {
                    return false;
                }
            }

            private List<string> GetAPList(string employeeID, int groupId)
            {
            //    IRepository<tblGroup> GroupRepository = new GenericRepository<tblGroup>();
                List<string> apList = new List<string>();

                string sessionName = DateTime.Now.ToString("yyyyMMddhh") + employeeID + "Group";

                if (HttpContext.Current.Session[sessionName] == null)
                {
                 //   tblGroup group = GroupRepository.Get(x => x.GroupId == groupId);
                   // var APNameEnList = JsonConvert.DeserializeObject<IEnumerable<AuthTransModel>>(group.Privilege);

                    // 權限管理的按鈕要 Level=5 才可以看到。
                    //if (group.Level == 5)
                    //    apList = APNameEnList.Where(x => x.HasAuthority == true).Select(x => x.APNameEn).ToList();
                    //else
                    //    apList = APNameEnList.Where(x => x.HasAuthority == true && x.APNameEn != APEnum.Authorization_GroupIndex.ToString()).Select(x => x.APNameEn).ToList();

                    HttpContext.Current.Session[sessionName] = apList;
                }
                else
                {
                    apList = (List<string>)HttpContext.Current.Session[sessionName];
                }
                
                return apList;
            }
        }
    }
}