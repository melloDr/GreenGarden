using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Image
{
    public Guid ImageId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Category> Categories { get; } = new List<Category>();

    public virtual ICollection<CategoryDetail> CategoryDetails { get; } = new List<CategoryDetail>();

    public virtual ICollection<FeedbackImage> FeedbackImages { get; } = new List<FeedbackImage>();

    public virtual ICollection<ProductItemImage> ProductItemImages { get; } = new List<ProductItemImage>();
}
