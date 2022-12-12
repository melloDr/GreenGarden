using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Service
{
    public Guid ServiceId { get; set; }

    public string? Name { get; set; }

    public Guid? ImageId { get; set; }

    public Guid? CreateBy { get; set; }

    public virtual Account? CreateByNavigation { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
