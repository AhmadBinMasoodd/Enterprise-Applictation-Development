using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UMS.DataAccess;

[Table("Teacher")]
public partial class Teacher
{
    [Key]
    [Column("pk_TeacherId")]
    public int PkTeacherId { get; set; }

    [Column("name")]
    [StringLength(25)]
    public string Name { get; set; } = null!;

    [Column("email")]
    [StringLength(25)]
    public string Email { get; set; } = null!;

    [Column("fk_DepartmentId")]
    public int FkDepartmentId { get; set; }

    [InverseProperty("FkTeacher")]
    public virtual ICollection<CourseAssignment> CourseAssignments { get; set; } = new List<CourseAssignment>();

    [ForeignKey("FkDepartmentId")]
    [InverseProperty("Teachers")]
    public virtual Department FkDepartment { get; set; } = null!;
}
