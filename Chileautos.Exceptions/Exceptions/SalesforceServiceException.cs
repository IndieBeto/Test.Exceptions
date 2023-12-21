namespace Chileautos.Exceptions.Exceptions
{
    public class SalesforceServiceException : Exception
    {
        public string Endpoint { get; private set; }
        public object LeadData { get; private set; }

        public SalesforceServiceException(string message, string endpoint, object leadData, Exception innerException)
            : base(message, innerException)
        {
            Endpoint = endpoint;
            LeadData = leadData;
        }
    }
}
