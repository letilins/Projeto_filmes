public interface IFilmesService
{
    List<Filme> ObterTodosFilmes();
    Filme ObterFilmePorNome(string nome);
    void AdicionarFilme(Filme filme);
    void AtualizarFilme(string nome, Filme filmeAtualizado);
    void ExcluirFilme(string nome);
}

public class FilmesService : IFilmesService
{
    private static List<Filme> filmes = new List<Filme>();

    public List<Filme> ObterTodosFilmes()
    {
        return filmes;
    }

    public Filme ObterFilmePorNome(string nome)
    {
        return filmes.Find(f => f.Nome == nome);
    }

    public void AdicionarFilme(Filme filme)
    {
        filmes.Add(filme);
    }

    public void AtualizarFilme(string nome, Filme filmeAtualizado)
    {
        var filme = filmes.Find(f => f.Nome == nome);
        if (filme != null)
        {
            filme.Nome = filmeAtualizado.Nome;
            filme.Ano = filmeAtualizado.Ano;
            filme.Diretor = filmeAtualizado.Diretor;
            filme.Atores = filmeAtualizado.Atores;
        }
    }

    public void ExcluirFilme(string nome)
    {
        var filme = filmes.Find(f => f.Nome == nome);
        if (filme != null)
        {
            filmes.Remove(filme);
        }
    }
}
