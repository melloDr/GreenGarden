using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class CategoryDetail
{
    public Guid CategoryDetailId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? ImageId { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
