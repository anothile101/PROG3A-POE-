using Practice_assignment.Models;

namespace Practice_assignment.Patterns.Factory
{
    /// <summary>
    /// Concrete Factory: produces a Contract with default Status based on ServiceLevel.
    /// Gold contracts default to Active; others default to Draft.
    /// </summary>
    public class ContractFactory : IContractFactory
    {
            public Contract CreateContract(int clientId, DateTime startDate, DateTime endDate, string serviceLevel)
            {
                var status = serviceLevel.Equals("Gold", StringComparison.OrdinalIgnoreCase)
                    ? ContractStatus.Active
                    : ContractStatus.Draft;

                return new Contract
                {
                    ClientId = clientId,
                    StartDate = startDate,
                    EndDate = endDate,
                    ServiceLevel = serviceLevel,
                    Status = status
                };
            }
        }
    }

