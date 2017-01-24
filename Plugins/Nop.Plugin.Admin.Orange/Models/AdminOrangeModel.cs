using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Admin.Orange.Models
{
    public class AdminOrangeModel : BaseNopEntityModel
    {
        public AdminOrangeModel()
        {
            this.Address = new AddressModel();
            AvailableStores = new List<SelectListItem>();
        }

        public AddressModel Address { get; set; }

        [NopResourceDisplayName("Plugins.Admin.Orange.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Plugins.Admin.Orange.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Plugins.Admin.Orange.Fields.PickupFee")]
        public decimal PickupFee { get; set; }

        [NopResourceDisplayName("Plugins.Admin.Orange.Fields.OpeningHours")]
        public string OpeningHours { get; set; }

        public List<SelectListItem> AvailableStores { get; set; }
        [NopResourceDisplayName("Plugins.Admin.Orange.Fields.Store")]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class AddressModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
        }

        public IList<SelectListItem> AvailableCountries { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.Country")]
        public int? CountryId { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.City")]
        [AllowHtml]
        public string City { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.Address1")]
        [AllowHtml]
        public string Address1 { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.ZipPostalCode")]
        [AllowHtml]
        public string ZipPostalCode { get; set; }
    }
}