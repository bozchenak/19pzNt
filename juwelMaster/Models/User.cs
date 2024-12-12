using System;
using System.Collections.Generic;

namespace juwelMaster;

public partial class User
{
    public int UserId { get; set; }

    public string? Fio { get; set; }

    public string? Phone { get; set; }

    public string? LoginUser { get; set; }

    public string? PasswordUser { get; set; }

    public string? TypeRole { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Request> RequestClients { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestMasters { get; set; } = new List<Request>();
}
