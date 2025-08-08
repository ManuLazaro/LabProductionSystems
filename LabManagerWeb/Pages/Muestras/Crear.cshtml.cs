using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using LabManagerWeb.Models;  
using LabManagerWeb.Data;  

namespace LabManagerWeb.Pages.Muestras  // Namespace, donde están las páginas de "Muestras".
{
    public class CrearModel : PageModel  // La clase "CrearModel" hereda de "PageModel", que es la clase base de Razor Pages.
    {
        private readonly AppDbContext _context;  // Declaramos el contexto de la base de datos. Se usa para acceder a los datos almacenados.

        public CrearModel(AppDbContext context)  // Este es el constructor de la clase "CrearModel". Recibe un "AppDbContext" para conectarse a la base de datos.
        {
            _context = context;  // Guardamos el contexto en una variable privada para usarlo más tarde.
        }

        [BindProperty]  // Este atributo enlaza el objeto Muestra con el formulario, es decir, lo vincula a la vista.
        public Muestra Muestra { get; set; } = new();  // Creamos una propiedad "Muestra" que representará los datos del formulario.

        public void OnGet()  // Método que maneja las solicitudes GET (cuando alguien accede a la página).
        {
        }

        public IActionResult OnPost()  // Este método maneja el envío del formulario (cuando se hace un POST).
        {
            if (!ModelState.IsValid)  
            {
                return Page(); 
            }

            // Si los datos son válidos, los agregamos a la base de datos:
            _context.Muestras.Add(Muestra);  // Añadimos la nueva muestra al contexto de la base de datos.
            _context.SaveChanges();  // Guardamos los cambios en la base de datos (es decir, guardamos la muestra).

            return RedirectToPage("/Index");  // Redirigimos al usuario a la página principal (o la que se configure como "Index").
        }
    }
}
