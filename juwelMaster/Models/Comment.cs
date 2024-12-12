using System;
using System.Collections.Generic;

namespace juwelMaster;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? MessageComments { get; set; }

    public int? MasterId { get; set; }

    public int? RequestId { get; set; }

    public virtual User? Master { get; set; }

    public virtual Request? Request { get; set; }
}
