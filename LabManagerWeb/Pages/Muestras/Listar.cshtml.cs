using Microsoft.AspNetCore.Mvc.RazorPages;
using LabManagerWeb.Models;
using LabManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace LabManagerWeb.Pages.Muestras
{
    public class ListarModel : PageModel
    {
        private readonly AppDbContext _context;  // Usamos AppDbContext para acceder a la base de datos

        public ListarModel(AppDbContext context)
        {
            _context = context;  // Guardamos el contexto en una variable para usarlo en el método OnGet
        }

        public IList<Muestra> Muestras { get; set; } = new List<Muestra>();  // Propiedad para almacenar las muestras obtenidas de la base de datos

        public void OnGet()  // Método OnGet se ejecuta cuando alguien accede a esta página
        {
            Muestras = _context.Muestras.ToList();  // Obtenemos todas las muestras de la base de datos y las almacenamos en la propiedad Muestras
        }
        
        public IActionResult OnPostEliminar(int id)
        {
            var muestra = _context.Muestras.Find(id);
            if (muestra != null)
            {
                _context.Muestras.Remove(muestra);
                _context.SaveChanges();
            }

            return RedirectToPage(); // Refresca la lista después de eliminar
        }

    }
}
