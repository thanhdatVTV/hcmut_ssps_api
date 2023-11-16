using System;
using System.Collections.Generic;

namespace HCMUT_SSPS.Models;

public partial class TblFileType
{
    public Guid Id { get; set; }

    public string? TypeName { get; set; }

    public bool? IsDelete { get; set; }

    public Guid? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserUpdated { get; set; }

    public DateTime? DateUpdated { get; set; }
}
