using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Size
{
    public Guid SizeId { get; set; }

    public string? Name { get; set; }

    public Guid? StatusId { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; } = new List<ProductSize>();
}
