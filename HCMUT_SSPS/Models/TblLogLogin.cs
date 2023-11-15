using System;
using System.Collections.Generic;

namespace HCMUT_SSPS.Models;

public partial class TblLogLogin
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public bool? IsDelete { get; set; }

    public Guid? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserUpdated { get; set; }

    public DateTime? DateUpdated { get; set; }
}
