using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UMS.DataAccess;

[Table("Department")]
public partial class Department
{
    [Key]
    [Column("pk_DepartmentId")]
    public int PkDepartmentId { get; set; }

    [StringLength(25)]
    public string DepartmentName { get; set; } = null!;

    [StringLength(40)]
    public string Location { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [InverseProperty("FkDepartmen")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [InverseProperty("Department")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("FkDepartment")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
