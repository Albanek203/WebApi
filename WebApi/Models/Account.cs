using System.Text.Json.Serialization;

namespace WebApi.Models;

public class Account {
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public Incident? Incident { get; set; }
    public List<Contact> Contacts { get; set; }
}