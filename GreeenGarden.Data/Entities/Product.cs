using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? CategoryDetailId { get; set; }

    public Guid? ServiceId { get; set; }

    public virtual CategoryDetail? CategoryDetail { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; } = new List<ProductSize>();

    public virtual Service? Service { get; set; }
}
