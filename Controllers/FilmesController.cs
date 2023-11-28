using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class FilmesController : ControllerBase
{   
    private readonly IFilmesService _filmesService;

    public FilmesController(IFilmesService filmesService)
    {
        _filmesService = filmesService;
    }
    
    private static List<Filme> filmes = new List<Filme>
    {
        new Filme { Nome = "Filme1", Ano = 2020, Diretor = "Diretor1", Atores = "Ator 1, ator 2" },
        new Filme { Nome = "Filme2", Ano = 2021, Diretor = "Diretor2", Atores = "Ator 3, ator 4" },
        new Filme { Nome = "Filme3", Ano = 2022, Diretor = "Diretor3", Atores = "Ator 5, ator 6" },
        new Filme { Nome = "Filme4", Ano = 2023, Diretor = "Diretor4", Atores = "Ator 7, ator 8" },
       
    };

    [HttpGet]
    public ActionResult<IEnumerable<Filme>> Get()
    {
        return Ok(filmes);
    }

    [HttpGet("{nome}")]
    public ActionResult<Filme> Get(string nome)
    {
        var filme = filmes.Find(f => f.Nome == nome);
        if (filme == null)
        {
            return NotFound();
        }
        return Ok(filme);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Filme filme)
    {
        //adicionar filme
        filmes.Add(filme);
        return CreatedAtAction(nameof(Get), new { nome = filme.Nome }, filme);
    }

    [HttpPut("{nome}")]
    public IActionResult Put(string nome, [FromBody] Filme filmeAtualizado)
    {
        var filme = filmes.Find(f => f.Nome == nome);
        if (filme == null)
        {
            return NotFound();
        }

        //atualizar filme 
        filme.Nome = filmeAtualizado.Nome;
        filme.Ano = filmeAtualizado.Ano;
        filme.Diretor = filmeAtualizado.Diretor;
        filme.Atores = filmeAtualizado.Atores;

        return NoContent();
    }

    [HttpDelete("{nome}")]
    public IActionResult Delete(string nome)
    {
        var filme = filmes.Find(f => f.Nome == nome);
        if (filme == null)
        {
            return NotFound();
        }

        // remover filme.
        filmes.Remove(filme);
        return NoContent();
    }
}
