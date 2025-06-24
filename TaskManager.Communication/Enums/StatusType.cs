namespace TaskManager.Communication.Enums;

/// <summary>
/// Define os status possíveis para uma tarefa.
/// </summary>
public enum StatusType
{
    /// <summary>
    /// Tarefa pendente, ainda não iniciada.
    /// </summary>
    todo = 1,

    /// <summary>
    /// Tarefa em andamento.
    /// </summary>
    in_progress = 2,

    /// <summary>
    /// Tarefa concluída.
    /// </summary>
    done = 3
}
