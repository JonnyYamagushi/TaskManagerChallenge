using TaskManager.Application.Repository;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.GetById;

/// <summary>
/// Caso de uso responsável por buscar uma tarefa específica utilizando seu ID.
/// </summary>
public class GetTaskByIdUseCase
{
    private readonly ITaskRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="GetTaskByIdUseCase"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de tarefas.</param>
    public GetTaskByIdUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executa a operação de busca de uma tarefa pelo ID informado.
    /// </summary>
    /// <param name="id">ID da tarefa que deseja consultar.</param>
    /// <returns>
    /// Um objeto <see cref="TaskResponse"/> contendo os dados da tarefa encontrada, 
    /// ou null caso não exista uma tarefa com o ID informado.
    /// </returns>
    public TaskResponse? Execute(Guid id)
    {
        var task = _repository.GetById(id);

        if (task == null)
            return null;

        return new TaskResponse
        {
            id = task.Id,
            title = task.Title,
            description = task.Description,
            priority = task.Priority,
            status = task.Status,
            createdAt = task.CreatedAt,
            deadLine = task.DeadLine
        };
    }
}
