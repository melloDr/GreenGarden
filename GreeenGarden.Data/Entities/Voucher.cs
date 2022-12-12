using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Voucher
{
    public Guid VoucherId { get; set; }

    public string? Name { get; set; }

    public string? VoucherCode { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Value { get; set; }

    public bool? IsGlobal { get; set; }

    public string? Quantity { get; set; }

    public string? UsedQuantity { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? CreateBy { get; set; }

    public virtual Account? CreateByNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
