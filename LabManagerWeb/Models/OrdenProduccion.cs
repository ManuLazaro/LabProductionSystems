public class OrdenProduccion
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Producto { get; set; }
    public string Linea { get; set; }
    public string Lote { get; set; }
    public int Cantidad { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }
    public string Estado { get; set; }
}