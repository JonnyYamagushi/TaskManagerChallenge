using TaskManager.Application.Repository;

namespace TaskManager.Application.UseCases.Task.Delete;

/// <summary>
/// Caso de uso responsável por excluir uma tarefa com base no seu ID.
/// </summary>
public class DeleteTaskUseCase
{
    private readonly ITaskRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="DeleteTaskUseCase"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de tarefas.</param>
    public DeleteTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executa a operação de exclusão de uma tarefa.
    /// </summary>
    /// <param name="id">ID da tarefa a ser excluída.</param>
    /// <returns>
    /// Retorna true se a tarefa foi encontrada e excluída com sucesso;
    /// Retorna false se a tarefa não foi encontrada.
    /// </returns>
    public bool Execute(Guid id)
    {
        var task = _repository.GetById(id);

        if (task == null)
            return false;

        _repository.Delete(id);
        return true;
    }
}
