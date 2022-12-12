using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class District
{
    public Guid DistrictId { get; set; }

    public string? Name { get; set; }

    public string? DistrictCode { get; set; }

    public string? CodeName { get; set; }

    public string? DivisionType { get; set; }

    public string? ProvinceCode { get; set; }

    public string? ShipingFee { get; set; }

    public Guid? StatusId { get; set; }

    public virtual ICollection<Ward> Wards { get; } = new List<Ward>();
}
