using TaskManager.Application.Entities;

namespace TaskManager.Application.Repository;

/// <summary>
/// Interface que define as operações de persistência para tarefas.
/// Define o contrato para adicionar, consultar, atualizar e excluir tarefas.
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Adiciona uma nova tarefa no repositório.
    /// </summary>
    /// <param name="task">Tarefa a ser adicionada.</param>
    void Add(TaskEntity task);

    /// <summary>
    /// Retorna todas as tarefas cadastradas no repositório.
    /// </summary>
    /// <returns>Uma coleção de tarefas.</returns>
    IEnumerable<TaskEntity> GetAll();

    /// <summary>
    /// Retorna uma tarefa específica pelo ID.
    /// </summary>
    /// <param name="id">ID da tarefa.</param>
    /// <returns>A tarefa encontrada ou null se não for localizada.</returns>
    TaskEntity? GetById(Guid id);

    /// <summary>
    /// Atualiza uma tarefa existente no repositório.
    /// </summary>
    /// <param name="task">Tarefa com os dados atualizados.</param>
    void Update(TaskEntity task);

    /// <summary>
    /// Remove uma tarefa do repositório com base no ID.
    /// </summary>
    /// <param name="id">ID da tarefa a ser removida.</param>
    void Delete(Guid id);
}
