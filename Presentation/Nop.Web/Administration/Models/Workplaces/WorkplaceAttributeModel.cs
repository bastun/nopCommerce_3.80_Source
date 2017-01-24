using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Nop.Admin.Validators.Customers;
using Nop.Web.Framework;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.Workplaces
{
    [Validator(typeof(CustomerAttributeValidator))]
    public partial class WorkplaceAttributeModel : BaseNopEntityModel, ILocalizedModel<WorkplaceAttributeLocalizedModel>
    {
        public WorkplaceAttributeModel()
        {
            Locales = new List<WorkplaceAttributeLocalizedModel>();
        }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Fields.AttributeControlType")]
        public int AttributeControlTypeId { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Fields.AttributeControlType")]
        [AllowHtml]
        public string AttributeControlTypeName { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }


        public IList<WorkplaceAttributeLocalizedModel> Locales { get; set; }

    }

    public partial class WorkplaceAttributeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.WorkplaceAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

    }
}