using System;
using System.Collections.Generic;

namespace juwelMaster;

public partial class Request
{
    public int RequestId { get; set; }

    public DateOnly? StartDate { get; set; }

    public string? HomeTechType { get; set; }

    public string? HomeTechModel { get; set; }

    public string? ProblemDescryption { get; set; }

    public string? RequestStatus { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public string? RepairParts { get; set; }

    public int? MasterId { get; set; }

    public int? ClientId { get; set; }

    public virtual User? Client { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? Master { get; set; }

    public virtual ICollection<RepairPart> RepairPartsNavigation { get; set; } = new List<RepairPart>();
}
