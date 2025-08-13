using System;

namespace BookRadar.Models
{
    public class BusquedaLibro
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string AutorBuscado { get; set; }
        public string Titulo { get; set; }
        public int? AnioPublicacion { get; set; }
        public string Editorial { get; set; }
        public DateTime FechaConsulta { get; set; }
    }
}
