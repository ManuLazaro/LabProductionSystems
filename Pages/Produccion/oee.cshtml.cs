using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LabManagerWeb.Pages.Produccion
{
    public class OEEModel : PageModel
    {
        public double Disponibilidad { get; set; }
        public double Rendimiento { get; set; }
        public double Calidad { get; set; }
        public double OeeTotal { get; set; }

        public List<LineaOEE> Lineas { get; set; } = new List<LineaOEE>();
        public List<CausaDeParo> CausasDeParo { get; set; } = new List<CausaDeParo>();

        public string FiltroFecha { get; set; } = "Últimos 7 días";
        public string FiltroTurno { get; set; } = "Turno noche";
        
        public void OnGet()
        {
            // KPIs generales
            Disponibilidad = CalcularDisponibilidad();
            Rendimiento = CalcularRendimiento();
            Calidad = CalcularCalidad();
            OeeTotal = CalcularOEE(Disponibilidad, Rendimiento, Calidad);

            // Datos de líneas (pueden provenir de la base de datos)
            Lineas = new List<LineaOEE>
            {
                new LineaOEE { Nombre = "Línea 1", Disponibilidad = 92, Rendimiento = 88, Calidad = 95, OEE = 77, Alerta = "🟢 OK" },
                new LineaOEE { Nombre = "Línea 2", Disponibilidad = 86, Rendimiento = 78, Calidad = 89, OEE = 60, Alerta = "🔴 Bajo rendimiento" },
            };

            // Causas de Paro
            CausasDeParo = new List<CausaDeParo>
            {
                new CausaDeParo { Causa = "Mantenimiento no programado", Porcentaje = 35 },
                new CausaDeParo { Causa = "Falta de materiales", Porcentaje = 25 },
                new CausaDeParo { Causa = "Limpieza", Porcentaje = 15 },
            };
        }

        private double CalcularDisponibilidad() => 92; // Simulamos un valor de ejemplo
        private double CalcularRendimiento() => 88; // Simulamos un valor de ejemplo
        private double CalcularCalidad() => 95; // Simulamos un valor de ejemplo

        private double CalcularOEE(double disponibilidad, double rendimiento, double calidad)
        {
            return Math.Round(disponibilidad * rendimiento * calidad / 1000000, 2); // OEE total
        }

        public class LineaOEE
        {
            public string Nombre { get; set; }
            public double OEE { get; set; }
            public double Disponibilidad { get; set; }
            public double Rendimiento { get; set; }
            public double Calidad { get; set; }
            public string Alerta { get; set; }
        }

        public class CausaDeParo
        {
            public string Causa { get; set; }
            public double Porcentaje { get; set; }
        }
    }
}
