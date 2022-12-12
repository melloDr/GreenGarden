using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class CartDetail
{
    public Guid CartDetailId { get; set; }

    public string? Service { get; set; }

    public Guid? ProductItemId { get; set; }

    public Guid? CartId { get; set; }

    public virtual Cart? Cart { get; set; }
}
