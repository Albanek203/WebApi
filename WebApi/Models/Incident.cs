namespace WebApi.Models;

public class Incident {
    public Guid Name { get; set; }
    public string Description { get; set; }
    public List<Account> Accounts { get; set; }
}