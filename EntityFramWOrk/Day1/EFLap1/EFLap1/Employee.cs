using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Employee")]
public class Employee
{
    [Key]
    [Column("SSN")]
    public int Ssn { get; set; }

    [Column("Fname")]
    public string? Fname { get; set; }

    [Column("Lname")]
    public string? Lname { get; set; }

    [Column("Address")]
    public string? Address { get; set; }

    [Column("Salary")]
    public int? Salary { get; set; }
}