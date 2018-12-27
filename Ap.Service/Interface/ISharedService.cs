using System.Web.Mvc;

namespace AP.Service.Interface
{
    public interface ISharedService
    {
        SelectList GetCustomerStatusTypeDDL(bool status);

        SelectList GetStatusTypeDDL();

        SelectList GetActionTypeDDL();
    }
}
