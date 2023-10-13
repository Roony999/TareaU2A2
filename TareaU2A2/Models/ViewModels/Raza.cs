namespace TareaU2A2.Models.ViewModels
{
    public class Raza
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string OtroNombre { get; set; } = null!;
        public string NomPais { get; set; } = null!;
        public int PesoMax { get; set; }
        public int PesoMin { get; set; }
        public int AlturaMax { get; set; }
        public int AlturaMin { get; set; }
        public int Esperanza {  get; set; }

        public string Patas { get; set; } = null!;
        public string cola { get; set; } = null!;
        public string Color { get; set;} = null!;
        public string Pelo { get; set; } = null!;
        public string Hocico { get; set; } = null!;
        public uint AmistadPerro { get; set; } 
        public uint EjercicioObligatorio { get; set; } 
        public uint Energia { get; set; } 
        public uint AmistaddDesconocida { get; set; } 
        public uint Entrenamiento { get; set; } 
        public uint Cepillado { get; set; }
        public List<perro> ListaPerros { get; set; }
    }
}
