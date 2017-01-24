using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
//using Nop.Admin.Validators.Customers;  // TODO
using Nop.Core.Domain.Catalog;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.Workplaces
{
   // [Validator(typeof(CustomerValidator))]  // TODO
    public partial class WorkplaceModel : BaseNopEntityModel
    {
        public WorkplaceModel()
        {
            this.AvailableTimeZones = new List<SelectListItem>();
            this.SendEmail = new SendEmailModel() { SendImmediately = true };
            this.SendPm = new SendPmModel();

            this.SelectedCustomerRoleIds= new List<int>();
            this.AvailableCustomerRoles = new List<SelectListItem>();

            this.AssociatedExternalAuthRecords = new List<AssociatedExternalAuthModel>();
            this.AvailableCountries = new List<SelectListItem>();
            this.AvailableStates = new List<SelectListItem>();
            this.AvailableVendors = new List<SelectListItem>();
            this.WorkplaceAttributes = new List<WorkplaceAttributeModel>();
            this.AvailableNewsletterSubscriptionStores = new List<StoreModel>();
            this.RewardPointsAvailableStores = new List<SelectListItem>();
        }

        public bool AllowUsersToChangeUsernames { get; set; }
        public bool UsernamesEnabled { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Username")]
        [AllowHtml]
        public string Username { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Password")]
        [AllowHtml]
        public string Password { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Vendor")]
        public int VendorId { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }

        //form fields & properties
        public bool GenderEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Gender")]
        public string Gender { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.FirstName")]
        [AllowHtml]
        public string FirstName { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.LastName")]
        [AllowHtml]
        public string LastName { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.FullName")]
        public string FullName { get; set; }
        
        public bool DateOfBirthEnabled { get; set; }
        [UIHint("DateNullable")]
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        public bool CompanyEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Company")]
        [AllowHtml]
        public string Company { get; set; }

        public bool StreetAddressEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.StreetAddress")]
        [AllowHtml]
        public string StreetAddress { get; set; }

        public bool StreetAddress2Enabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.StreetAddress2")]
        [AllowHtml]
        public string StreetAddress2 { get; set; }

        public bool ZipPostalCodeEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.ZipPostalCode")]
        [AllowHtml]
        public string ZipPostalCode { get; set; }

        public bool CityEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.City")]
        [AllowHtml]
        public string City { get; set; }

        public bool CountryEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Country")]
        public int CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }

        public bool StateProvinceEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.StateProvince")]
        public int StateProvinceId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

        public bool PhoneEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Phone")]
        [AllowHtml]
        public string Phone { get; set; }

        public bool FaxEnabled { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Fax")]
        [AllowHtml]
        public string Fax { get; set; }

        public List<WorkplaceAttributeModel> WorkplaceAttributes { get; set; }





        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.AdminComment")]
        [AllowHtml]
        public string AdminComment { get; set; }
        
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.IsTaxExempt")]
        public bool IsTaxExempt { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Active")]
        public bool Active { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Affiliate")]
        public int AffiliateId { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Affiliate")]
        public string AffiliateName { get; set; }




        //time zone
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.TimeZoneId")]
        [AllowHtml]
        public string TimeZoneId { get; set; }

        public bool AllowCustomersToSetTimeZone { get; set; }

        public IList<SelectListItem> AvailableTimeZones { get; set; }





        //EU VAT
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.VatNumber")]
        [AllowHtml]
        public string VatNumber { get; set; }

        public string VatNumberStatusNote { get; set; }

        public bool DisplayVatNumber { get; set; }





        //registration date
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.LastActivityDate")]
        public DateTime LastActivityDate { get; set; }

        //IP adderss
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.IPAddress")]
        public string LastIpAddress { get; set; }


        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.LastVisitedPage")]
        public string LastVisitedPage { get; set; }


        //customer roles
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.CustomerRoles")]
        public string CustomerRoleNames { get; set; }
        public List<SelectListItem> AvailableCustomerRoles { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.CustomerRoles")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCustomerRoleIds { get; set; }


        //newsletter subscriptions (per store)
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Newsletter")]
        public List<StoreModel> AvailableNewsletterSubscriptionStores { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.Fields.Newsletter")]
        public int[] SelectedNewsletterSubscriptionStoreIds { get; set; }



        //reward points history
        public bool DisplayRewardPointsHistory { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.AddRewardPointsValue")]
        public int AddRewardPointsValue { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.AddRewardPointsMessage")]
        [AllowHtml]
        public string AddRewardPointsMessage { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.AddRewardPointsStore")]
        public int AddRewardPointsStoreId { get; set; }
        [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.AddRewardPointsStore")]
        public IList<SelectListItem> RewardPointsAvailableStores { get; set; }



        //send email model
        public SendEmailModel SendEmail { get; set; }
        //send PM model
        public SendPmModel SendPm { get; set; }
        //send the welcome message
        public bool AllowSendingOfWelcomeMessage { get; set; }
        //re-send the activation message
        public bool AllowReSendingOfActivationMessage { get; set; }

        [NopResourceDisplayName("Admin.Workplaces.Workplaces.AssociatedExternalAuth")]
        public IList<AssociatedExternalAuthModel> AssociatedExternalAuthRecords { get; set; }


        #region Nested classes

        public partial class StoreModel : BaseNopEntityModel
        {
            public string Name { get; set; }
        }

        public partial class AssociatedExternalAuthModel : BaseNopEntityModel
        {
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.AssociatedExternalAuth.Fields.Email")]
            public string Email { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.AssociatedExternalAuth.Fields.ExternalIdentifier")]
            public string ExternalIdentifier { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.AssociatedExternalAuth.Fields.AuthMethodName")]
            public string AuthMethodName { get; set; }
        }

        public partial class RewardPointsHistoryModel : BaseNopEntityModel
        {
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.Store")]
            public string StoreName { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.Points")]
            public int Points { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.PointsBalance")]
            public int PointsBalance { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.Message")]
            [AllowHtml]
            public string Message { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.RewardPoints.Fields.Date")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class SendEmailModel : BaseNopModel
        {
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.SendEmail.Subject")]
            [AllowHtml]
            public string Subject { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.SendEmail.Body")]
            [AllowHtml]
            public string Body { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.SendEmail.SendImmediately")]
            public bool SendImmediately { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.SendEmail.DontSendBeforeDate")]
            [UIHint("DateTimeNullable")]
            public DateTime? DontSendBeforeDate { get; set; }
        }

        public partial class SendPmModel : BaseNopModel
        {
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.SendPM.Subject")]
            public string Subject { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.SendPM.Message")]
            public string Message { get; set; }
        }

        public partial class OrderModel : BaseNopEntityModel
        {
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.ID")]
            public override int Id { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.OrderStatus")]
            public string OrderStatus { get; set; }
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.OrderStatus")]
            public int OrderStatusId { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.PaymentStatus")]
            public string PaymentStatus { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.ShippingStatus")]
            public string ShippingStatus { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.OrderTotal")]
            public string OrderTotal { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.Store")]
            public string StoreName { get; set; }

            [NopResourceDisplayName("Admin.Workplaces.Workplaces.Orders.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class ActivityLogModel : BaseNopEntityModel
        {
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.ActivityLog.ActivityLogType")]
            public string ActivityLogTypeName { get; set; }
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.ActivityLog.Comment")]
            public string Comment { get; set; }
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.ActivityLog.CreatedOn")]
            public DateTime CreatedOn { get; set; }
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.ActivityLog.IpAddress")]
            public string IpAddress { get; set; }
        }

        public partial class BackInStockSubscriptionModel : BaseNopEntityModel
        {
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.BackInStockSubscriptions.Store")]
            public string StoreName { get; set; }
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.BackInStockSubscriptions.Product")]
            public int ProductId { get; set; }
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.BackInStockSubscriptions.Product")]
            public string ProductName { get; set; }
            [NopResourceDisplayName("Admin.Workplaces.Workplaces.BackInStockSubscriptions.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class WorkplaceAttributeModel : BaseNopEntityModel
        {
            public WorkplaceAttributeModel()
            {
                Values = new List<WorkplaceAttributeValueModel>();
            }

            public string Name { get; set; }

            public bool IsRequired { get; set; }

            /// <summary>
            /// Default value for textboxes
            /// </summary>
            public string DefaultValue { get; set; }

            public AttributeControlType AttributeControlType { get; set; }

            public IList<WorkplaceAttributeValueModel> Values { get; set; }

        }

        public partial class WorkplaceAttributeValueModel : BaseNopEntityModel
        {
            public string Name { get; set; }

            public bool IsPreSelected { get; set; }
        }

        #endregion
    }
}