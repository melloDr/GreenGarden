using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Order
{
    public Guid OrderId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public double? Total { get; set; }

    public string? Deposit { get; set; }

    public string? InvoiceType { get; set; }

    public double? TransportFee { get; set; }

    public string? Transaction { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? StartDateRent { get; set; }

    public DateTime? EndDateRent { get; set; }

    public Guid? VoucherId { get; set; }

    public Guid? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Voucher? Voucher { get; set; }
}
