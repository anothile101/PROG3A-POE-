using Practice_assignment.Models;

namespace Practice_assignment.Patterns.Factory
{
    /// <summary>
    /// Factory Pattern (GoF Creational):
    /// Abstracts the creation of Contract objects based on the service level.
    /// This decouples the controller from the specifics of how each contract type is initialized.
    /// </summary>
    public interface IContractFactory
    {
            Contract CreateContract(int clientId, DateTime startDate, DateTime endDate, string serviceLevel);
        }
    }

