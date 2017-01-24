using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Nop.Admin.Validators.Customers;
using Nop.Web.Framework;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.Workplaces
{
    [Validator(typeof(CustomerAttributeValueValidator))]
    public partial class WorkplaceAttributeValueModel : BaseNopEntityModel, ILocalizedModel<WorkplaceAttributeValueLocalizedModel>
    {
        public WorkplaceAttributeValueModel()
        {
            Locales = new List<WorkplaceAttributeValueLocalizedModel>();
        }

        public int WorkplaceAttributeId { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<WorkplaceAttributeValueLocalizedModel> Locales { get; set; }

    }

    public partial class WorkplaceAttributeValueLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}