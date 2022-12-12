using System;
using System.Collections.Generic;

namespace GreeenGarden.Data.Entities;

public partial class FeedbackImage
{
    public Guid FeedbackImageId { get; set; }

    public Guid? ImageId { get; set; }

    public Guid? FeedbackId { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual Image? Image { get; set; }
}
