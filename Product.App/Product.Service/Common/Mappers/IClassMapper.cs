namespace Product.Service.Common.Mappers
{
    /// <summary>
    /// Interface for classes that map from one class to another.
    /// </summary>
    /// <remarks>
    /// This interface only exists you can make a collection of <see cref="IClassMapper{TFrom, TTo}"/>
    /// instances, you should not use it directly.
    /// </remarks>
    public interface IClassMapper
    {
    }

    /// <summary>
    /// Interface for classes that map from one class to another.
    /// </summary>
    /// <typeparam name="TFrom">The type converting from.</typeparam>
    /// <typeparam name="TTo">The type converting to.</typeparam>
    public interface IClassMapper<in TFrom, out TTo> : IClassMapper
    {
        /// <summary>
        /// Maps the specified object instance  to another.
        /// </summary>
        /// <param name="from">The object to map from.</param>
        /// <param name="context">The mapping context.</param>
        /// <returns>
        /// An instance of the mapped object
        /// </returns>
        TTo Map(TFrom from, object context = null);
    }
}
