using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crud.Models;

public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [Column("firstName")]
    [StringLength(10)]
    public string? FirstName { get; set; }

    [Column("lastName")]
    [StringLength(15)]
    public string? LastName { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("salary")]
    public double? Salary { get; set; }

    [Column("department")]
    [StringLength(50)]
    public string? Department { get; set; }
}
