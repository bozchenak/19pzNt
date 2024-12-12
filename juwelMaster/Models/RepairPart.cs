using System;
using System.Collections.Generic;

namespace juwelMaster;

public partial class RepairPart
{
    public int RepairPartId { get; set; }

    public string? PartName { get; set; }

    public int? RequestId { get; set; }

    public virtual Request? Request { get; set; }
}
