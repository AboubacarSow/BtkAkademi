using System.ComponentModel.DataAnnotations;
namespace BtkAkademi.Models;

public class Candidate
{
  [Required(ErrorMessage=" This field is required .")]
  public string? Email{get; set;}

  [Required(ErrorMessage=" This field is required .")]
  public string? FirstName{get; set;}

  [Required(ErrorMessage=" This field is required .")]
  public string? LastName{get; set ;}
  
  public string? FullName=>$"{FirstName} {LastName?.ToUpper()}";

  public int? Age { get; set; }

  public string? SelectedCourse{get; set;}

  public DateTime? ApplyAt{get;}

  public Candidate()
  {
    ApplyAt=DateTime.Now;
  }

}
