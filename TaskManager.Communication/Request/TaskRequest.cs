using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Request;

/// <summary>
/// Representa os dados necessários para criar ou atualizar uma tarefa.
/// </summary>
public class TaskRequest
{
    /// <summary>
    /// Título da tarefa.
    /// </summary>
    public string title { get; set; } = string.Empty;

    /// <summary>
    /// Descrição detalhada da tarefa.
    /// </summary>
    public string description { get; set; } = string.Empty;

    /// <summary>
    /// Prioridade da tarefa (Baixa, Média ou Alta).
    /// </summary>
    public PriorityType priority { get; set; }

    /// <summary>
    /// Data limite para conclusão da tarefa (Deadline).
    /// </summary>
    public DateOnly deadLine { get; set; }
}
