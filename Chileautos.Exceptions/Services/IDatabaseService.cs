using Chileautos.Exceptions.Exceptions;

namespace Chileautos.Exceptions.Services
{
    public interface IDatabaseService
    {
        Task SaveLeadAsync(object lead);
    }

    public class DatabaseService : IDatabaseService
    {
        public async Task SaveLeadAsync(object lead)
        {
            try
            {
                // Save to database logic
            }
            catch (Exception ex)
            {
                // LOGGER LOGIC

                throw new DatabaseException("Failed to execute stored procedure",
                                            "sp_SaveLead",
                                            lead, // Pass the entire lead object
                                            ex);
            }
        }
    }
}
