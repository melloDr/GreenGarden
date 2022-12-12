using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class Feedback
{
    public Guid FeedbackId { get; set; }

    public string? Comment { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductItemId { get; set; }

    public Guid? CreateBy { get; set; }

    public virtual Customer? CreateByNavigation { get; set; }

    public virtual ICollection<FeedbackImage> FeedbackImages { get; } = new List<FeedbackImage>();

    public virtual ProductItem? ProductItem { get; set; }
}
