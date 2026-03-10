using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UMS.DataAccess;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("pk_StudentId")]
    public int PkStudentId { get; set; }

    [StringLength(25)]
    public string StudentName { get; set; } = null!;

    public int Age { get; set; }

    [StringLength(30)]
    public string Email { get; set; } = null!;

    public int DepartmentId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EnrollmentDate { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Students")]
    public virtual Department Department { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
