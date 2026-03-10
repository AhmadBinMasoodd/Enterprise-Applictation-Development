using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UMS.DataAccess;

[Table("Table")]
public partial class Table
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
    [InverseProperty("Tables")]
    public virtual Department Department { get; set; } = null!;
}
