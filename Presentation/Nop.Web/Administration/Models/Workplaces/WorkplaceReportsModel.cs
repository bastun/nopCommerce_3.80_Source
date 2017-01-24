using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.Workplaces
{
    public partial class WorkplaceReportsModel : BaseNopModel
    {
        public BestCustomersReportModel BestCustomersByOrderTotal { get; set; }
        public BestCustomersReportModel BestCustomersByNumberOfOrders { get; set; }
    }
}