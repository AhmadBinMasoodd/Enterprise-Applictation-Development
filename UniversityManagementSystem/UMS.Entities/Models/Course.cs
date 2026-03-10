using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UMS.DataAccess;

[Table("Course")]
public partial class Course
{
    [Key]
    [Column("pk_CourseId")]
    public int PkCourseId { get; set; }

    [StringLength(25)]
    public string CourseName { get; set; } = null!;

    public int Credits { get; set; }

    [Column("fk_DepartmenId")]
    public int FkDepartmenId { get; set; }

    [InverseProperty("FkCourse")]
    public virtual ICollection<CourseAssignment> CourseAssignments { get; set; } = new List<CourseAssignment>();

    [InverseProperty("Course")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [ForeignKey("FkDepartmenId")]
    [InverseProperty("Courses")]
    public virtual Department FkDepartmen { get; set; } = null!;
}
