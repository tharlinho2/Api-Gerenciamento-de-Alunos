using Alunos.Application.Alunos.Commands;
using Alunos.Application.Resultado;
using Alunos.Domain.Alunos.Interface;
using Flunt.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alunos.Api.Controllers.Aluno
{

    [ApiController]
    [Route("api/alunos")]
    [Produces("application/json")]
    public class AlunosController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IAlunoRepository _alunoRepository;

        public AlunosController(IMediator mediator, IAlunoRepository aluno)
        {
            _mediator = mediator;
            _alunoRepository = aluno;
        }

        /// <summary>
        /// Método responsável por cadastrar um novo aluno
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarAluno([FromBody] CadastrarAlunoCommand command)
        {
            if (command == null)
                return BadRequest();
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Método responsável por recuperar lista de alunos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ObterAlunos()
        {
            var alunos = _alunoRepository.ObterTodos().ToList();
            
            return Ok(alunos);
        }

        /// <summary>
        /// Método responsável por atualizar aluno por id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarAlunoPorId(AtualizarAlunoPorIdCommand command)
        {
            if (command == null)
                return BadRequest();
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            var aluno = _alunoRepository.ObterAlunoPorId(command.Id);
            return Ok(aluno);
        }

        /// <summary>
        /// Método responsável por deletar aluno por id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("deletar")]
        public async Task<ActionResult> DeletarAlunoPorId(DeletarAlunoPorIdCommand command)
        {
            if(command == null)
                return BadRequest("Objeto invalido");

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
