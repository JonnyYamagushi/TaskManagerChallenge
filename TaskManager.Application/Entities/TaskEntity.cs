using TaskManager.Communication.Enums;

namespace TaskManager.Application.Entities;

/// <summary>
/// Representa a entidade de uma tarefa dentro do domínio da aplicação.
/// Contém informações como título, descrição, prioridade, status, data de criação e prazo (deadline).
/// </summary>
public class TaskEntity
{
    /// <summary>
    /// Identificador único da tarefa.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Status atual da tarefa (Ex.: todo, doing, done).
    /// </summary>
    public StatusType Status { get; set; } = StatusType.todo;

    /// <summary>
    /// Prioridade da tarefa (Ex.: Low, Medium, High).
    /// </summary>
    public PriorityType Priority { get; set; }

    /// <summary>
    /// Título da tarefa.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Descrição detalhada da tarefa.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Data em que a tarefa foi criada.
    /// </summary>
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// Data limite para a conclusão da tarefa (Deadline).
    /// </summary>
    public DateOnly DeadLine { get; set; }
}