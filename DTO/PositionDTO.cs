using System.ComponentModel.DataAnnotations;

namespace HR_Service.DTO;

public class PositionDTO
{
    [Required]
    public string name { get; set; } = string.Empty;
    [Required]
    public string code { get; set; } = string.Empty;
    [Required]
    public int level { get; set; }
    [Required]
    public bool is_active { get; set; }
}