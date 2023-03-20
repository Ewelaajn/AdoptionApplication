using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdoptionApplication.Shared.DTO;

public class BasicResponse
{
    [NotMapped]
    [JsonPropertyName("ErrorMessage")]
    public string? ErrorMessage { get; set; } = "";
}