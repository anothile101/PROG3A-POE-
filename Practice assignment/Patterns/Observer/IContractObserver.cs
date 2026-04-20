using Practice_assignment.Models;

namespace Practice_assignment.Patterns.Observer
{
    /// <summary>
    /// Observer Pattern (GoF Behavioural):
    /// Allows multiple listeners to react to contract status changes
    /// without the core service needing to know about them (loose coupling).
    /// </summary>
    public interface IContractObserver
        {
            Task OnContractStatusChangedAsync(ContractStatusChangedEvent contractEvent);
        }

        public class ContractStatusChangedEvent
        {
            public int ContractId { get; init; }
            public ContractStatus OldStatus { get; init; }
            public ContractStatus NewStatus { get; init; }
            public DateTime ChangedAt { get; init; } = DateTime.UtcNow;
        }
    }

