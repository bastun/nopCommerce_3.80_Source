using Nop.Data.Mapping;
using Nop.Plugin.Admin.Orange.Domain;

namespace Nop.Plugin.Admin.Orange.Data
{
    public partial class AdminOrangeMap : NopEntityTypeConfiguration<AdminOrange>
    {
        public AdminOrangeMap()
        {
            this.ToTable("AdminOrange");
            this.HasKey(point => point.Id);
            this.Property(point => point.PickupFee).HasPrecision(18, 4);
        }
    }
}