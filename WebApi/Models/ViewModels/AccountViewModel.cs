using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ViewModels;

public record AccountViewModel([Required] string Name
                             , [Required] string FirstName
                             , [Required] string LastName
                             , [Required] string Email);