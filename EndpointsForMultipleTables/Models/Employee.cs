using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EndpointsForMultipleTables.Models;

public partial class Employee
{
    public int EmpNo { get; set; }

    public string EmpName { get; set; } = null!;

    [JsonIgnore]
    public int DepNo { get; set; }

    //It represents the association between an "Employee" and its associated "Department" through the DepNo foreign key.
    [JsonIgnore]
    public virtual Department? DepNoNavigation { get; set; }
}
