namespace Edid.Exceptions
{
    /// <summary>
    /// Exception thrown when a descriptor is invalid.
    /// </summary>
    public class InvalidDescriptorException : Exception
    {
        public InvalidDescriptorException(string message) : base(message)
        {
        }
    }
}
