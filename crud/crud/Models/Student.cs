using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crud.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    public int Id { get; set; }

    [Column("SName")]
    [StringLength(30)]
    public string? Sname { get; set; }

    [Column("SAge")]
    public int? Sage { get; set; }
}
