using Microsoft.AspNetCore.Mvc;
using BookRadar.Models;
using BookRadar.Data;
using Newtonsoft.Json;

namespace BookRadar.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public LibrosController(AppDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        public IActionResult Buscar() => View();

        [HttpPost]
        public async Task<IActionResult> Buscar(string autor)
        {
            if (string.IsNullOrWhiteSpace(autor)) return View();

            string url = $"https://openlibrary.org/search.json?author={Uri.EscapeDataString(autor)}";
            var response = await _httpClient.GetStringAsync(url);

            var resultado = JsonConvert.DeserializeObject<LibroApiResult>(response);

            var libros = resultado?.Docs?.Take(100).ToList(); 

            bool yaExiste = _context.HistorialBusquedas.Any(x =>
                x.AutorBuscado == autor &&
                x.FechaConsulta > DateTime.Now.AddMinutes(-1)
            );
            if (!yaExiste)
            {
                foreach (var libro in libros)
                {
                    var busqueda = new BusquedaLibro
                    {
                        Autor = string.Join(", ", libro.author_name),
                        Titulo = libro.Title,
                        AnioPublicacion = libro.First_Publish_Year,
                        Editorial = libro.Publisher ?? "Desconocida",
                        FechaConsulta = DateTime.Now,
                        AutorBuscado = autor
                    };

                    _context.HistorialBusquedas.Add(busqueda);
                }
            }


            await _context.SaveChangesAsync();

            return View("Resultados", libros);
        }

        public IActionResult Historial()
        {
            var historial = _context.HistorialBusquedas
                .OrderByDescending(x => x.FechaConsulta)
                .ToList();

            return View(historial);
        }
    }
}
