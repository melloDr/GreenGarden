using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Account
{
    public Guid AccountId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Name { get; set; }

    public Guid? ImageId { get; set; }

    public Guid? RoleId { get; set; }

    public Guid? StatusId { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<Category> Categories { get; } = new List<Category>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Service> Services { get; } = new List<Service>();

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();
}
