using TaskManager.Application.Repository;
using TaskManager.Communication.Enums;
using TaskManager.Communication.Request;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.Register;

/// <summary>
/// Caso de uso responsável por registrar (criar) uma nova tarefa.
/// </summary>
public class RegisterTaskUseCase
{
    private readonly ITaskRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="RegisterTaskUseCase"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de tarefas.</param>
    public RegisterTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executa a operação de criação de uma nova tarefa.
    /// </summary>
    /// <param name="request">Dados da tarefa a ser criada.</param>
    /// <returns>Objeto <see cref="TaskResponse"/> contendo os dados da tarefa criada.</returns>
    public TaskResponse Execute(TaskRequest request)
    {
        var task = new Entities.TaskEntity
        {
            Id = Guid.NewGuid(),
            Status = StatusType.todo,
            Priority = request.priority,
            Title = request.title,
            Description = request.description,
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            DeadLine = request.deadLine
        };

        _repository.Add(task);

        return new TaskResponse
        {
            id = task.Id,
            status = task.Status,
            priority = task.Priority,
            title = task.Title,
            description = task.Description,
            createdAt = task.CreatedAt,
            deadLine = task.DeadLine
        };
    }
}
