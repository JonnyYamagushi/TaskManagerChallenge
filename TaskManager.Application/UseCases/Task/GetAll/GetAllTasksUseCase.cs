using TaskManager.Application.Repository;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.GetAll;

/// <summary>
/// Caso de uso responsável por listar todas as tarefas cadastradas.
/// </summary>
public class GetAllTasksUseCase
{
    private readonly ITaskRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="GetAllTasksUseCase"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de tarefas.</param>
    public GetAllTasksUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executa a operação de listagem de todas as tarefas.
    /// </summary>
    /// <returns>Lista de tarefas convertidas para o formato de resposta (<see cref="TaskResponse"/>).</returns>
    public List<TaskResponse> Execute()
    {
        var tasks = _repository.GetAll();

        return tasks.Select(task => new TaskResponse
        {
            id = task.Id,
            title = task.Title,
            description = task.Description,
            priority = task.Priority,
            status = task.Status,
            createdAt = task.CreatedAt,
            deadLine = task.DeadLine
        }).ToList();
    }
}