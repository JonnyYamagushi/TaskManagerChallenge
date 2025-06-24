using System.Threading.Tasks;
using TaskManager.Application.Entities;

namespace TaskManager.Application.Repository;

/// <summary>
/// Implementação do repositório de tarefas em memória.
/// Armazena os dados apenas durante o tempo de execução da aplicação.
/// </summary>
public class InMemoryTaskRepository : ITaskRepository
{
    /// <summary>
    /// Lista interna que armazena as tarefas em memória.
    /// </summary>
    private readonly List<TaskEntity> _tasks = new();

    /// <summary>
    /// Adiciona uma nova tarefa no repositório.
    /// </summary>
    /// <param name="task">Tarefa a ser adicionada.</param>
    public void Add(TaskEntity task)
    {
        _tasks.Add(task);
    }

    /// <summary>
    /// Retorna todas as tarefas cadastradas no repositório.
    /// </summary>
    /// <returns>Uma lista de tarefas.</returns>
    public IEnumerable<TaskEntity> GetAll() => _tasks;

    /// <summary>
    /// Retorna uma tarefa específica pelo ID.
    /// </summary>
    /// <param name="id">ID da tarefa.</param>
    /// <returns>A tarefa correspondente ou null se não for encontrada.</returns>
    public TaskEntity? GetById(Guid id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    /// <summary>
    /// Atualiza uma tarefa existente no repositório.
    /// </summary>
    /// <param name="task">Tarefa com os dados atualizados.</param>
    public void Update(TaskEntity task)
    {
        var index = _tasks.FindIndex(t => t.Id == task.Id);

        if (index != -1)
        {
            _tasks[index] = task;
        }
    }

    /// <summary>
    /// Remove uma tarefa do repositório com base no ID.
    /// </summary>
    /// <param name="id">ID da tarefa a ser removida.</param>
    public void Delete(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
    }
}
