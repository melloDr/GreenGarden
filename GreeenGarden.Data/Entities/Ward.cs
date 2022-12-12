using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Ward
{
    public Guid WardId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? CodeName { get; set; }

    public string? DivisionType { get; set; }

    public string? DistrictCode { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? DistrictId { get; set; }

    public virtual District? District { get; set; }
}
