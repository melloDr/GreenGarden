using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public Guid? ImageId { get; set; }

    public Guid? StatusId { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();
}
