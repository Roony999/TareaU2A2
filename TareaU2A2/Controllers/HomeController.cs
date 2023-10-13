using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaU2A2.Models.Entities;
using TareaU2A2.Models.ViewModels;

namespace TareaU2A2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string c)
        {
            PerrosContext context = new PerrosContext();
            indexviewM vm = new();
            if(c == null )
            {
            

                var datos = context.Razas.Select(x => new onedog
                {
                    id = (int)x.Id,
                    Nombre = x.Nombre ?? " "
                }).OrderBy(x => x.Nombre).ToList();
                vm.muchosperros = datos;
                return View(vm);
            }
            else
            {
                var datos = context.Razas.Where(x => c == x.Nombre.Substring(0, 1)).Select(x => new onedog
                {
                    id = (int)x.Id,
                    Nombre = x.Nombre ?? " "
                }).OrderBy(x => x.Nombre).ToList();
                vm.muchosperros = datos;
                return View(vm);
            }
           
        }

        [Route("/pais")]
        public IActionResult pais() 
        {
            PerrosContext context = new PerrosContext();
            paisViewM vm = new();
            var datos = context.Paises.Select(x=> new pasisesViewM
            {
                Id = (int)x.Id,
                Nombre= x.Nombre ?? " ",
                perros = x.Razas.Select(x => new perro
                {
                    Id= (int)x.Id,
                    Nombre = x.Nombre,
                }),
            }).OrderBy(x=> x.Nombre).ToList();
            vm.Paisesbr = datos;
            return View(vm); 
        }
        [Route ("raza/{nombre}")]
        public IActionResult Raza(string nombre)
        {
            nombre = nombre.Replace("-", " ");
            PerrosContext context = new PerrosContext();

            Random random = new Random();
            List<int> Perrosabajo = context.Razas.Select(x => (int)x.Id).ToList();
            List<perro> Losotros = new();
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int numero = rand.Next(0, Perrosabajo.Count);
                var Perro = context.Razas.Select(x => new perro
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre,
                }).Where(x => x.Id == Perrosabajo[numero]).First();
                Losotros.Add(Perro);
            }

            Raza vm = new();
            vm.ListaPerros = Losotros;
            var datos = context.Razas.Where(x => x.Nombre == nombre).Include(x=> x.Estadisticasraza ).Select(x=> new Raza
            {
                Id =  (int)x.Id,
                Name = x.Nombre ?? " ",
                Description = x.Descripcion,
                OtroNombre = x.OtrosNombres ?? " ",
                NomPais = x.Nombre,
                PesoMax = (int)x.PesoMax,
                PesoMin = (int)x.PesoMin,
                AlturaMax = (int)x.AlturaMax,
                AlturaMin = (int)x.AlturaMin,
                Esperanza = (int)x.EsperanzaVida,
                Pelo = x.Caracteristicasfisicas.Pelo,
                Patas = x.Caracteristicasfisicas.Patas,
                cola = x.Caracteristicasfisicas.Cola,
                Color = x.Caracteristicasfisicas.Color,
                Hocico = x.Caracteristicasfisicas.Hocico,
                AmistaddDesconocida = x.Estadisticasraza.AmistadDesconocidos,
                AmistadPerro = x.Estadisticasraza.AmistadPerros,
                Cepillado = x.Estadisticasraza.NecesidadCepillado,
                EjercicioObligatorio = x.Estadisticasraza.EjercicioObligatorio,
                Energia = x.Estadisticasraza.NivelEnergia,
                Entrenamiento = x.Estadisticasraza.FacilidadEntrenamiento,
        }).OrderBy(x => x.Name).FirstOrDefault();
            return View(datos);
        }
    }
}
