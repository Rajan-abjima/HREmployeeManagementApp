﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Core.Models;
public class EmployeeModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeID { get; set; }

    public Guid Identifier { get; set; }

    [Required(ErrorMessage ="First name is required", AllowEmptyStrings =false)]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required", AllowEmptyStrings = false)]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Gender Required", AllowEmptyStrings = false)]
    [MaxLength(50)]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "DOB Required", AllowEmptyStrings = false)]
    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Address required", AllowEmptyStrings = false)]
    public string? PresentAddress { get; set; }

    [Required(ErrorMessage = "Contact Number required", AllowEmptyStrings = false)]
    [RegularExpression("^[0-9]{10}$", ErrorMessage = "This should be 10 digit numeric data")]
    public string? MobileNumber { get; set; }

    [Required(ErrorMessage = "Designation Required", AllowEmptyStrings = false)]
    public string? Designation { get; set; }

    [Required]
    public DateTime JoiningDate { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime LeavingDate { get; set; }

    [Required]
    public bool AdminStatus { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }
}