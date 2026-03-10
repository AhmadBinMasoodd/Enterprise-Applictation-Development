using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UMS.DataAccess;

[Table("Enrollment")]
public partial class Enrollment
{
    [Key]
    [Column("pk_EnrollmentId")]
    public int PkEnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Semester { get; set; }

    [StringLength(5)]
    public string? Grade { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Enrollments")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual Student Student { get; set; } = null!;
}
