using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class OrderDetail
{
    public Guid OrderDetailId { get; set; }

    public double? Price { get; set; }

    public Guid? ProductItemId { get; set; }

    public Guid? OrderId { get; set; }

    public virtual Order? Order { get; set; }
}
