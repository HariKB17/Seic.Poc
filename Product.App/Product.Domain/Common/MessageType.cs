namespace Product.Domain.Common
{
    /// <summary>
    /// Represents the possible types for a <see cref="Message"/>.
    /// </summary>
    public enum MessageType
    {
        Authorization,
        Validation,
        Error,
        Information,
        Warning,
        Success
    }
}
