using TreinoAPI.Context;
using TreinoAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TreinoAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunosContext _context;

        public AlunoController(AlunosContext context)
        {
            _context = context;
        }

        [HttpPost("AdicionarAluno")]
        public IActionResult Create(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId),new {id = aluno.Id}, aluno);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var aluno = _context.Aluno.Find(id);

            if (aluno == null)
            {
                return NotFound("Aluno não encontrado!");
            }

            return Ok(aluno);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var alunos = _context.Aluno.Where(x => x.Nome.Contains(nome));
            return Ok(alunos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Aluno aluno)
        {
            var alunoBanco = _context.Aluno.Find(id);

            if(alunoBanco == null)
               return NotFound();

            alunoBanco.Nome = aluno.Nome;
            alunoBanco.Matricula = aluno.Matricula;
            alunoBanco.SituacaoBoleto = aluno.SituacaoBoleto;

            _context.Aluno.Update(alunoBanco);
            _context.SaveChanges();

            return Ok(alunoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)    
        {
            var alunoBanco = _context.Aluno.Find(id);

            if(alunoBanco == null)
               return NotFound();

            _context.Aluno.Remove(alunoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}