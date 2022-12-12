using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class ProductSize
{
    public Guid ProductSizeId { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? SizeId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
