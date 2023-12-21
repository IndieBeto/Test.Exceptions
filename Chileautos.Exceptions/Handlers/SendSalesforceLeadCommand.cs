using Chileautos.Exceptions.Exceptions;
using Chileautos.Exceptions.Services;

namespace Chileautos.Exceptions.Handlers
{
    public class CreateLeadCommandHandler 
    {
        private readonly IDatabaseService _databaseService;
        private readonly ISalesforceService _salesforceService;
        private readonly ILogger<CreateLeadCommandHandler> _logger;

        public CreateLeadCommandHandler(IDatabaseService databaseService, ISalesforceService salesforceService, ILogger<CreateLeadCommandHandler> logger)
        {
            _databaseService = databaseService;
            _salesforceService = salesforceService;
            _logger = logger;
        }

        public async Task<bool> Handle(object command, CancellationToken cancellationToken)
        {
            try
            {
                // Step 1: Send the lead to Salesforce
                await _salesforceService.CreateLeadAsync(command);

                // Step 2: Save the lead in the database
                await _databaseService.SaveLeadAsync(command);

                return true; // Indicate success
            }
            catch (SalesforceServiceException ex)
            {
                // Example handling logic:

                // 1. Try to send the lead again

                // 2. Fallback mechanism: Save the lead elsewhere

                // 3. User notification: Put the lead on a queue to later submition

                return false; 
            }
            catch (DatabaseException ex)
            {
                // Example handling logic:

                // 1. Transaction management: Roll back

                // 2. Retry logic: 

                // 3. Alternative storage: g

                return false; // Indicate that the primary operation did not succeed
            }
            catch (Exception ex)
            {
                // General exception handling
                // General handling logic
            }

            return false;
        }
    }
}
