using AP.Service.Helper;
using AP.Service.Interface;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace AP.Service
{
    public class SharedService : ISharedService
    {
        #region check date
        public class SEDate
        {
            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }
        }

        private DateTime sDate = DateTime.Now.AddYears(-20);
        private DateTime eDate = DateTime.Now.AddHours(1);

        public SEDate checkSEDate(DateTime startDate, DateTime endDate)
        {
            SEDate seDate = new SEDate();

            if (startDate < sDate)
                seDate.StartDate = sDate;
            else
                seDate.StartDate = DateTime.Parse(startDate.ToString("yyyy/MM/dd") + " 00:00:00");

            if (endDate < sDate)
                seDate.EndDate = eDate;
            else
                seDate.EndDate = DateTime.Parse(endDate.ToString("yyyy/MM/dd") + " 23:59:59");

            return seDate;
        }

        public SEDate checkSEDateTime(DateTime startDate, DateTime endDate)
        {
            SEDate seDate = new SEDate();

            if (startDate < sDate)
                seDate.StartDate = sDate;
            else
                seDate.StartDate = startDate;

            if (endDate < sDate)
                seDate.EndDate = eDate;
            else
                seDate.EndDate = endDate;

            return seDate;
        }
        #endregion

        #region ddl
        #region FaceType
        public enum CustomerStatus
        {           
            [Description("強制停用")]
            Default = 0,
         
            [Description("未申請")]
            Feature = 1,        
        }

        public SelectList GetCustomerStatusTypeDDL(bool status)
        {
                 
                var ddlList = Enum.GetValues(typeof(CustomerStatus)).Cast<CustomerStatus>()
                       .Select(x => new
                       {
                           Text = x.GetEnumDescription(),
                           Value = ((int)x).ToString()
                       });
            
            SelectList selectList = new SelectList(ddlList, "Value", "Text");

            return selectList;
        }
        #endregion

        #region Status (Enable/Disable)
        public enum statusType
        {
            /// <summary>
            /// 請選擇
            /// </summary>
            [Description("請選擇")]
            Default = 0,

            /// <summary>
            /// 啟用
            /// </summary>
            [Description("啟用")]
            Enable = 1,

            /// <summary>
            /// 停用
            /// </summary>
            [Description("停用")]
            Disable = 2,
        }

        public SelectList GetStatusTypeDDL()
        {
            var ddlList = Enum.GetValues(typeof(statusType)).Cast<statusType>()
                        .Select(x => new
                        {
                            Text = x.GetEnumDescription(),
                            Value = ((int)x).ToString()
                        }).OrderBy(x => x.Value);


            SelectList selectList = new SelectList(ddlList, "Value", "Text");


            return selectList;
        }
        #endregion

        #region FaceType
        public enum ActionTypeEnum
        {
            [Description("登入")]
            Login = 1,

            [Description("登出")]
            Logoff = 2,

            [Description("查詢")]
            Search = 3,

            [Description("新增")]
            Create = 4,

            [Description("修改")]
            Edit = 5,

            [Description("刪除")]
            Delete = 6
        }

        public SelectList GetActionTypeDDL()
        {

            var ddlList = Enum.GetValues(typeof(ActionTypeEnum)).Cast<ActionTypeEnum>()
                   .Select(x => new
                   {
                       Text = x.GetEnumDescription()
                   });

            SelectList selectList = new SelectList(ddlList, "Text", "Text");

            return selectList;
        }
        #endregion
        #endregion
    }
}
