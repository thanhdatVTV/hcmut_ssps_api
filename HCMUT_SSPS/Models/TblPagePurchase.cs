using System;
using System.Collections.Generic;

namespace HCMUT_SSPS.Models;

public partial class TblPagePurchase
{
    public Guid? UserId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public int? PageCount { get; set; }

    public int? PaymentStatus { get; set; }

    public bool? IsDelete { get; set; }

    public Guid? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserUpdated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int Id { get; set; }
}
