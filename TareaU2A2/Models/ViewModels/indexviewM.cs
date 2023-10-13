namespace TareaU2A2.Models.ViewModels
{
    public class indexviewM
    {
        public List<onedog> muchosperros { get; set; } = null!;
    }

    public class onedog
    {
        public int id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
