using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Response;

/// <summary>
/// Representa os dados de resposta de uma tarefa retornada pela API.
/// </summary>
public class TaskResponse
{
    /// <summary>
    /// Identificador único da tarefa.
    /// </summary>
    public Guid id { get; set; }

    /// <summary>
    /// Status atual da tarefa (Ex.: todo, in_progress, done).
    /// </summary>
    public StatusType status { get; set; }

    /// <summary>
    /// Título da tarefa.
    /// </summary>
    public string title { get; set; } = string.Empty;

    /// <summary>
    /// Descrição detalhada da tarefa.
    /// </summary>
    public string description { get; set; } = string.Empty;

    /// <summary>
    /// Prioridade da tarefa (Ex.: high, medium, low).
    /// </summary>
    public PriorityType priority { get; set; }

    /// <summary>
    /// Data de criação da tarefa.
    /// </summary>
    public DateOnly createdAt { get; set; }

    /// <summary>
    /// Data limite para conclusão da tarefa (Deadline).
    /// </summary>
    public DateOnly deadLine { get; set; }
}
