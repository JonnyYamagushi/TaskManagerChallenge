using TaskManager.Application.Repository;
using TaskManager.Communication.Request;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.Update;

/// <summary>
/// Caso de uso responsável por atualizar os dados de uma tarefa existente.
/// </summary>
public class UpdateTaskUseCase
{
    private readonly ITaskRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="UpdateTaskUseCase"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de tarefas.</param>
    public UpdateTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executa a operação de atualização dos dados de uma tarefa.
    /// </summary>
    /// <param name="id">ID da tarefa a ser atualizada.</param>
    /// <param name="request">Dados atualizados da tarefa.</param>
    /// <returns>
    /// Um objeto <see cref="TaskResponse"/> contendo os dados atualizados da tarefa, 
    /// ou null se a tarefa não for encontrada.
    /// </returns>
    public TaskResponse? Execute(Guid id, TaskRequest request)
    {
        var task = _repository.GetById(id);

        if (task == null)
            return null;

        task.Title = request.title;
        task.Description = request.description;
        task.Priority = request.priority;
        task.DeadLine = request.deadLine;

        _repository.Update(task);

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
