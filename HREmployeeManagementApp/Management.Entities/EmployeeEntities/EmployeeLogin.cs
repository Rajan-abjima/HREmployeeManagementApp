﻿using System.ComponentModel.DataAnnotations;

namespace Management.Enities.EmployeeEntities;
public class EmployeeLogin
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string Password { get; set; } = string.Empty;
}