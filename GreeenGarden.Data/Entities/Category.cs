using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? ImageId { get; set; }

    public Guid? CreateBy { get; set; }

    public virtual ICollection<CategoryDetail> CategoryDetails { get; } = new List<CategoryDetail>();

    public virtual Account? CreateByNavigation { get; set; }

    public virtual Image? Image { get; set; }
}
