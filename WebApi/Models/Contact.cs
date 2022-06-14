using System.Text.Json.Serialization;

namespace WebApi.Models;

public class Contact {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public Account Account { get; set; } 
}