namespace ML
{
    public class Restaurante
    {
        public int IdRestaurante { get; set; }
        public string? Nombre { get; set; } = default!;
        public int? CantidadEmpleados { get; set; }  
        public int? CapacidadClientes { get; set; }
        public string FechaInauguracion { get; set; } = default!;
        public decimal? Calificacion { get; set; }
    }
}