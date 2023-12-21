namespace Chileautos.Exceptions.Exceptions
{
    public class DatabaseException : Exception
    {
        public string ProcedureName { get; private set; }
        public object LeadData { get; private set; }

        public DatabaseException(string message, string procedureName, object leadData, Exception innerException)
            : base(message, innerException)
        {
            ProcedureName = procedureName;
            LeadData = leadData;
        }
    }
}
