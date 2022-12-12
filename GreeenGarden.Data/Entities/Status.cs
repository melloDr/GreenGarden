using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Status
{
    public Guid StatusId { get; set; }

    public string? Name { get; set; }
}
