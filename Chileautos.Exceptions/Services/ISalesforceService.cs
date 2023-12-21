using Chileautos.Exceptions.Exceptions;

namespace Chileautos.Exceptions.Services
{
    public interface ISalesforceService
    {
        Task CreateLeadAsync(object lead);
    }
    public class SalesforceService : ISalesforceService
    {

        public async Task CreateLeadAsync(object lead)
        {
            try
            {
                // send lead async
            }
            catch (Exception ex)
            {
                // LOGGER LOGIC

                throw new SalesforceServiceException("Failed to call Salesforce API",
                                                     "api/salesforce/create-lead", // API endpoint
                                                     lead, // The lead data being sent
                                                     ex);

            }
        }
    }
}
