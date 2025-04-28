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

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public List<Livro> Livros { get; set; }
}

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    
    public List<Emprestimo> Emprestimos { get; set; }
}

public class Emprestimo
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public Livro Livro { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }
}
