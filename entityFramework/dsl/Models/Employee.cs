using System;
using System.Collections.Generic;

namespace dsl.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public double? Salary { get; set; }

    public string? Department { get; set; }
}
