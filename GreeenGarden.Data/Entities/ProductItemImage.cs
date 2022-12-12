using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class ProductItemImage
{
    public Guid ProductItemImageId { get; set; }

    public Guid? ProductItemId { get; set; }

    public Guid? ImageId { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ProductItem? ProductItem { get; set; }
}
