using System;
using System.Collections.Generic;
using EndpointsForMultipleTables.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json.Serialization;

namespace EndpointsForMultipleTables.Models;

public partial class Department
{
    public int DepNo { get; set; }

    public string DepName { get; set; } = null!;

    public string Location { get; set; } = null!;

    //[JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}


