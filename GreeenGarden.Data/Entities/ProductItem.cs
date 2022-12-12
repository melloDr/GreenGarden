using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class ProductItem
{
    public Guid ProductItemId { get; set; }

    public Guid? ProductId { get; set; }

    public string? Name { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? ProductSizeId { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<ProductItemImage> ProductItemImages { get; } = new List<ProductItemImage>();
}
