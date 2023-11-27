using System;
using System.Collections.Generic;

namespace HCMUT_SSPS.Models;

public partial class TblPrinter
{
    public Guid Id { get; set; }

    public string? Brand { get; set; }

    public string? PrinterModel { get; set; }

    public string? Description { get; set; }

    public int? LocationId { get; set; }

    public int? Status { get; set; }

    public bool? IsDelete { get; set; }

    public Guid? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserUpdated { get; set; }

    public DateTime? DateUpdated { get; set; }
}
