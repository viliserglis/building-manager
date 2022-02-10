using System.ComponentModel.DataAnnotations;

namespace BuildingManager.Web.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Ievadiet lietotājvārdu")]
    [Display(Name = "Lietotājs")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Parole nav norādīta")]
    [Display(Name = "Parole")]
    public string Password { get; set; }
}