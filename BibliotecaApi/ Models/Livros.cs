namespace BibliotecaApi.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AnoPublicacao { get; set; }
        public bool Disponivel { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
