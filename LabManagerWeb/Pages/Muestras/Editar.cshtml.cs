using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LabManagerWeb.Models;
using LabManagerWeb.Data;

namespace LabManagerWeb.Pages.Muestras
{
    public class EditarModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditarModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Muestra Muestra { get; set; }

        public IActionResult OnGet(int id)  // Método OnGet para cargar la muestra específica por su ID
        {
            Muestra = _context.Muestras.FirstOrDefault(m => m.Id == id);
            if (Muestra == null)
            {
                return RedirectToPage("/Muestras/Listar");  // Si no se encuentra la muestra, redirigimos a la lista
            }
            return Page();  // Si encontramos la muestra, mostramos el formulario de edición
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();  // Si los datos no son válidos, volvemos a mostrar el formulario
            }

            var muestraExistente = _context.Muestras.FirstOrDefault(m => m.Id == Muestra.Id);

            if (muestraExistente == null)
            {
                return RedirectToPage("/Muestras/Listar");  // Si la muestra no existe, redirigimos al listado
            }

            // Aquí asignamos los nuevos valores a la muestra existente
            muestraExistente.Nombre = Muestra.Nombre;
            muestraExistente.Tipo = Muestra.Tipo;
            muestraExistente.Resultado = Muestra.Resultado;
            muestraExistente.Fecha = Muestra.Fecha;
            muestraExistente.Responsable = Muestra.Responsable;

            // Marcamos la entidad como modificada para asegurarnos de que el contexto de EF la actualiza
            _context.Muestras.Update(muestraExistente);

            // Guardamos los cambios
            _context.SaveChanges();

            return RedirectToPage("/Muestras/Listar");  // Redirigimos al listado de muestras después de guardar los cambios
        }
}
}
