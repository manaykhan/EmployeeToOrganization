using System.ComponentModel.DataAnnotations;
namespace CrudAPI.Contracts;

public class CreateEmployeeRequest
{
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? Title { get; set; }

    
    [StringLength(100)]
    public string? Salary { get; set; }

}