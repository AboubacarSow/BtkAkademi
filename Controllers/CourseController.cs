using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace BtkAkademi.Controllers;

public class CourseController:Controller
{
    public IActionResult Index()
    {
        //Ici on récupère les applications à partir de notre repository
        var model= Repository.Applications;
        return View(model);
    }
    public IActionResult Apply()
    {
        return View();
    }
    //  Sur cette action nous devons indiquer sur quelle methode elle va travailler
    //Dans ce cas nous indiquons ici au naviguateur que cette méthode travaille sur 
    //le principe de HttpPost Ceci est un attribut
    [HttpPost] 
    //Pour assurer une bonne sécurité on peut également utiliser un attribut ValidateAntiForgeryToken
    [ValidateAntiForgeryToken]
    //Dans le paramètre de la méthode Apply on peut indiquer(ce qui est d'ailleurs plus propre et recommandé)
    //dequelle provient les informations concernant notre modèle.
    //Dans notre cas, il s'agit d'une forme
    public IActionResult Apply([FromForm]Candidate model)
    {
        //ICI on effectue une validation des données venant de notre forme 
        if(Repository.Applications.Any(c=> c.Email==model.Email))
        {
            ModelState.AddModelError("", "There is already an application that belongs you");
        }
        if (ModelState.IsValid)
        {
            Repository.Add(model);
            return View("Feedback", model);
        }
        return View();
        
    }
}
