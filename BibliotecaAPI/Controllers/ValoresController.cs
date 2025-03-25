using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/valores")]
    public class ValoresController : ControllerBase
    {
        // RepositorioValores es un tipo concreto
        //private readonly RepositorioValores repositorioValores; // RepositorioValores debemos configurar esta clase como servicio
        private readonly IRepositorioValores repositorioValores; // Principio de inversión de dependencias
        private readonly ServicioTransient transient11;
        private readonly ServicioTransient transient12;
        private readonly ServicioScoped scoped1;
        private readonly ServicioScoped scoped2;
        private readonly ServicioSingleton singleton;

        //public ValoresController(RepositorioValores repositorioValores) 
        public ValoresController(IRepositorioValores repositorioValores,
            ServicioTransient transient11,
            ServicioTransient transient12,
            ServicioScoped scoped1,
            ServicioScoped scoped2,
            ServicioSingleton singleton
            )
        { 
            this.repositorioValores = repositorioValores;
            this.transient11 = transient11;
            this.transient12 = transient12;
            this.scoped1 = scoped1;
            this.scoped2 = scoped2;
            this.singleton = singleton;
        }

        [HttpGet("servicios-tiempo-de-vida")]
        public IActionResult GetServiciosTiempoDeVida()
        {
            return Ok(new
            { 
                Transients = new
                {
                    transient11 = transient11.ObtenerGuid,
                    transient12 = transient12.ObtenerGuid
                },
                Scopeds = new
                {
                    scoped1 = scoped1.ObtenerGuid,
                    scoped2 = scoped2.ObtenerGuid
                },
                Singleton  = singleton.ObtenerGuid
            });
        }
        //private readonly 
        [HttpGet]
        public IEnumerable<Valor> Get()
        {
            //var repositorioValores = new RepositorioValores(); // Acoplamiento fuerte, inflexibilidad para responder un cambio del negocio
            return repositorioValores.ObtenerValores();
            /*return new List<Valor>
            {
                new Valor{ id = 1, Nombre = "Valor 1"},
                new Valor{ id = 2, Nombre = "Valor 2"}
            };*/
        }
    }
}
