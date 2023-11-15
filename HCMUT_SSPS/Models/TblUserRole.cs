using System;
using System.Collections.Generic;

namespace HCMUT_SSPS.Models;

public partial class TblUserRole
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? RoleId { get; set; }

    public bool? IsDelete { get; set; }

    public Guid? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserUpdated { get; set; }

    public DateTime? DateUpdated { get; set; }
}
