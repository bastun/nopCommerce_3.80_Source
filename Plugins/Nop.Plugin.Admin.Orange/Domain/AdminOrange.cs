using Nop.Core;

namespace Nop.Plugin.Admin.Orange.Domain
{
    /// <summary>
    /// Represents a Orange Admin
    /// </summary>
    public partial class AdminOrange : BaseEntity
    {
        /// <summary>
        /// Gets or sets a name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets an address identifier
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets a fee for the pickup
        /// </summary>
        public decimal PickupFee { get; set; }

        /// <summary>
        /// Gets or sets an oppening hours
        /// </summary>
        public string OpeningHours { get; set; }

        /// <summary>
        /// Gets or sets a store identifier
        /// </summary>
        public int StoreId { get; set; }
    }
}