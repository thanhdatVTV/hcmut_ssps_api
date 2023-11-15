using System;
using System.Collections.Generic;

namespace HCMUT_SSPS.Models;

public partial class TblUser
{
    public Guid Id { get; set; }

    public string? CodeId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? FullName { get; set; }

    public int? FacultyId { get; set; }

    public string? FacultyName { get; set; }

    public int? CourseId { get; set; }

    public string? CourseName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Type { get; set; }

    public bool? IsDelete { get; set; }

    public Guid UserCreated { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid? UserUpdated { get; set; }

    public DateTime? DateUpdated { get; set; }
}
