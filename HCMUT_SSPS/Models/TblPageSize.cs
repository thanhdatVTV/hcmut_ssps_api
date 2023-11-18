using System;
using System.Collections.Generic;

namespace HCMUT_SSPS.Models;

public partial class TblPageSize
{
    public int Id { get; set; }

    public string? PageSizeName { get; set; }

    public bool? IsDelete { get; set; }

    public Guid? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserUpdated { get; set; }

    public DateTime? DateUpdated { get; set; }
}
