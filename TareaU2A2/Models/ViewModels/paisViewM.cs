namespace TareaU2A2.Models.ViewModels
{
    public class paisViewM
    {
        public List<pasisesViewM> Paisesbr { get; set; } = null!;
    }

    public class pasisesViewM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<perro> perros { get; set; } = null!;
    }

    public class perro 
    {
        public int Id { get; set; } 
        public string Nombre { get; set;} = null!;
    }
}
