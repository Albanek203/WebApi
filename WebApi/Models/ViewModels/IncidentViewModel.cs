using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ViewModels;

public record IncidentViewModel([Required] string Name
                              , [Required] string FirstName
                              , [Required] string LastName
                              , [Required] string Email
                              , [Required] string Description);