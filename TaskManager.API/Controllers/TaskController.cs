using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Repository;
using TaskManager.Application.UseCases.Task.Delete;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Application.UseCases.Task.GetById;
using TaskManager.Application.UseCases.Task.Register;
using TaskManager.Application.UseCases.Task.Update;
using TaskManager.Communication.Request;
using TaskManager.Communication.Response;
using TaskManager.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager.API.Controllers;

/// <summary>
/// Controller responsável por gerenciar operações de tarefas.
/// Permite criar, listar, obter por ID, atualizar e deletar tarefas.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TaskController(ITaskRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Cria uma nova tarefa.
    /// </summary>
    /// <param name="request">Dados da tarefa a ser criada.</param>
    /// <returns>Retorna a tarefa criada com status 201 Created, ou erro caso falhe.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateTask([FromBody] TaskRequest request)
    {
        try
        {
            var useCase = new RegisterTaskUseCase(_repository);

            var response = useCase.Execute(request);

            return CreatedAtAction(nameof(GetById), new { id = response.id }, response);
        }
        catch (Exception ex)
        {
            Functions.EscreveLog("TaskController/CreateTask", ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { StatusCode = 500, Message = "Erro interno no servidor." });
        }
    }

    /// <summary>
    /// Retorna todas as tarefas cadastradas.
    /// </summary>
    /// <returns>Lista de tarefas existentes com status 200 OK.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<TaskResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        try
        {
            var tasks = new GetAllTasksUseCase(_repository).Execute();
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            Functions.EscreveLog("TaskController/CreateTask", ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { StatusCode = 500, Message = "Erro interno no servidor." });
        }
    }

    /// <summary>
    /// Retorna uma tarefa específica pelo ID.
    /// </summary>
    /// <param name="id">ID da tarefa a ser consultada.</param>
    /// <returns>Retorna a tarefa encontrada ou 404 Not Found se não existir.</returns>
    [HttpGet("{id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var task = new GetTaskByIdUseCase(_repository).Execute(id);

        if (task == null) return NotFound();

        return Ok(task);
    }

    /// <summary>
    /// Atualiza os dados de uma tarefa existente.
    /// </summary>
    /// <param name="id">ID da tarefa que será atualizada.</param>
    /// <param name="request">Dados atualizados da tarefa.</param>
    /// <returns>Retorna a tarefa atualizada ou 404 Not Found se não for encontrada.</returns>
    [HttpPut("{id:Guid}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    public IActionResult Update(Guid id, [FromBody] TaskRequest request)
    {
        var task = new UpdateTaskUseCase(_repository).Execute(id, request);

        if (task == null) return NotFound();

        return Ok(task);
    }

    /// <summary>
    /// Exclui uma tarefa com base no ID informado.
    /// </summary>
    /// <param name="id">ID da tarefa a ser excluída.</param>
    /// <returns>Retorna 204 No Content se deletado com sucesso, ou 404 Not Found se não for encontrada.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(Guid id)
    {
        var success = new DeleteTaskUseCase(_repository).Execute(id);

        if (!success) return NotFound();

        return NoContent();
    }
}