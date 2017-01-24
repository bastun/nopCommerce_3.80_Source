using System;
using System.Linq;
using System.Web.Mvc;
using Nop.Core.Domain.Common;
using Nop.Plugin.Admin.Orange.Domain;
using Nop.Plugin.Admin.Orange.Models;
using Nop.Plugin.Admin.Orange.Services;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Directory;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Security;

namespace Nop.Plugin.Admin.Orange.Controllers
{
    [AdminAuthorize]
    public class AdminOrangeController : BasePluginController
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly IAdminOrangeService _AdminOrangeService;
        private readonly IStoreService _storeService;

        #endregion

        #region Ctor

        public AdminOrangeController(IAddressService addressService,
            ICountryService countryService,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            IAdminOrangeService AdminOrangeService,
            IStoreService storeService)
        {
            this._addressService = addressService;
            this._countryService = countryService;
            this._localizationService = localizationService;
            this._permissionService = permissionService;
            this._AdminOrangeService = AdminOrangeService;
            this._storeService = storeService;
        }

        #endregion

        #region Methods

        [ChildActionOnly]
        public ActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return Content("Access denied");

            return View("~/Plugins/Admin.Orange/Views/AdminOrange/Configure.cshtml");
        }
        
        /*
        [HttpPost]
        [AdminAntiForgery]
        public ActionResult List(DataSourceRequest command)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return Content("Access denied");

            var pickupPoints = _AdminOrangeService.GetAllStorePickupPoints();
            var model = pickupPoints.Select(x =>
            {
                var store = _storeService.GetStoreById(x.StoreId);
                return new AdminOrangeModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OpeningHours = x.OpeningHours,
                    PickupFee = x.PickupFee,
                    StoreName = store != null ? store.Name
                        : x.StoreId == 0 ? _localizationService.GetResource("Admin.Configuration.Settings.StoreScope.AllStores") : string.Empty
                };
            }).ToList();

            return Json(new DataSourceResult
            {
                Data = model,
                Total = pickupPoints.TotalCount
            });
        }

        public ActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return Content("Access denied");

            var model = new AdminOrangeModel();
            model.Address.AvailableCountries.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.Address.SelectCountry"), Value = "0" });
            foreach (var country in _countryService.GetAllCountries(showHidden: true))
                model.Address.AvailableCountries.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
            model.AvailableStores.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.Configuration.Settings.StoreScope.AllStores"), Value = "0" });
            foreach (var store in _storeService.GetAllStores())
                model.AvailableStores.Add(new SelectListItem { Text = store.Name, Value = store.Id.ToString() });

            return View("~/Plugins/Admin.Orange/Views/AdminOrange/Create.cshtml", model);
        }

        [HttpPost]
        [AdminAntiForgery]
        public ActionResult Create(string btnId, string formId, AdminOrangeModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return Content("Access denied");

            var address = new Address
            {
                Address1 = model.Address.Address1,
                City = model.Address.City,
                CountryId = model.Address.CountryId,
                ZipPostalCode = model.Address.ZipPostalCode,
                CreatedOnUtc = DateTime.UtcNow
            };
            _addressService.InsertAddress(address);

            var pickupPoint = new StorePickupPoint
            {
                Name = model.Name,
                Description = model.Description,
                AddressId = address.Id,
                OpeningHours = model.OpeningHours,
                PickupFee = model.PickupFee,
                StoreId = model.StoreId
            };
            _AdminOrangeService.InsertStorePickupPoint(pickupPoint);

            ViewBag.RefreshPage = true;
            ViewBag.btnId = btnId;
            ViewBag.formId = formId;

            return View("~/Plugins/AdminOrange/Views/AdminOrange/Create.cshtml", model);
        }

        public ActionResult Edit(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return Content("Access denied");

            var pickupPoint = _AdminOrangeService.GetStorePickupPointById(id);
            if (pickupPoint == null)
                return RedirectToAction("Configure");

            var model = new AdminOrangeModel
            {
                Id = pickupPoint.Id,
                Name = pickupPoint.Name,
                Description = pickupPoint.Description,
                OpeningHours = pickupPoint.OpeningHours,
                PickupFee = pickupPoint.PickupFee,
                StoreId = pickupPoint.StoreId
            };

            var address = _addressService.GetAddressById(pickupPoint.AddressId);
            if (address != null)
            {
                model.Address = new AddressModel
                {
                    Address1 = address.Address1,
                    City = address.City,
                    CountryId = address.CountryId,
                    ZipPostalCode = address.ZipPostalCode
                };
            }
            model.Address.AvailableCountries.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.Address.SelectCountry"), Value = "0" });
            foreach (var country in _countryService.GetAllCountries(showHidden: true))
                model.Address.AvailableCountries.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString(), Selected = (address != null && country.Id == address.CountryId) });
            model.AvailableStores.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.Configuration.Settings.StoreScope.AllStores"), Value = "0" });
            foreach (var store in _storeService.GetAllStores())
                model.AvailableStores.Add(new SelectListItem { Text = store.Name, Value = store.Id.ToString(), Selected = store.Id == model.StoreId });

            return View("~/Plugins/Admin.Orange/Views/AdminOrange/Edit.cshtml", model);
        }

        [HttpPost]
        [AdminAntiForgery]
        public ActionResult Edit(string btnId, string formId, AdminOrangeModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return Content("Access denied");

            var pickupPoint = _AdminOrangeService.GetStorePickupPointById(model.Id);
            if (pickupPoint == null)
                return RedirectToAction("Configure");

            var address = _addressService.GetAddressById(pickupPoint.AddressId) ?? new Address { CreatedOnUtc = DateTime.UtcNow };
            address.Address1 = model.Address.Address1;
            address.City = model.Address.City;
            address.CountryId = model.Address.CountryId;
            address.ZipPostalCode = model.Address.ZipPostalCode;
            if (address.Id > 0)
                _addressService.UpdateAddress(address);
            else
                _addressService.InsertAddress(address);

            pickupPoint.Name = model.Name;
            pickupPoint.Description = model.Description;
            pickupPoint.AddressId = address.Id;
            pickupPoint.OpeningHours = model.OpeningHours;
            pickupPoint.PickupFee = model.PickupFee;
            pickupPoint.StoreId = model.StoreId;
            _Admin.OrangeService.UpdateStorePickupPoint(pickupPoint);

            ViewBag.RefreshPage = true;
            ViewBag.btnId = btnId;
            ViewBag.formId = formId;

            return View("~/Plugins/Admin.Orange/Views/AdminOrange/Edit.cshtml", model);
        }

        [HttpPost]
        [AdminAntiForgery]
        public ActionResult Delete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return Content("Access denied");

            var pickupPoint = _AdminOrangeService.GetStorePickupPointById(id);
            if (pickupPoint == null)
                return RedirectToAction("Configure");

            var address = _addressService.GetAddressById(pickupPoint.AddressId);
            if (address != null)
                _addressService.DeleteAddress(address);
            _AdminOrangeService.DeleteStorePickupPoint(pickupPoint);

            return new NullJsonResult();
        }
        */
        #endregion
    }
}
