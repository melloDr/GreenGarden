using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Cart
{
    public Guid CartId { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; } = new List<CartDetail>();

    public virtual Customer? Customer { get; set; }
}
