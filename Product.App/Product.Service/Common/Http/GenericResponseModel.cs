using System;
using System.Collections.Generic;

namespace Product.Service.Common
{
    /// <summary>
    /// Base class for all responses from service methods.
    /// </summary>
    public abstract class GenericResponseModel
    {
        /// <summary>
        /// Collection of all error messages.
        /// </summary>
        public List<MessageModel> ErrorMessages { get; set; }

        /// <summary>
        /// Collection of all warning messages.
        /// </summary>
        public List<MessageModel> WarningMessages { get; set; }

        /// <summary>
        /// Collection of all information messages.
        /// </summary>
        public List<MessageModel> InformationMessages { get; set; }

        /// <summary>
        /// Collection of all success messages.
        /// </summary>
        public List<MessageModel> SuccessMessages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResponseModel{TModel}"/> class.
        /// </summary>
        protected GenericResponseModel()
        {
            ErrorMessages = new List<MessageModel>();
            WarningMessages = new List<MessageModel>();
            InformationMessages = new List<MessageModel>();
            SuccessMessages = new List<MessageModel>();
        }
    }

    /// <summary>
    /// Represents a generic model that holds various information messages along with result.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <remarks>
    /// Used as a ViewModel when being returned from services. Any change will alter the contract of
    /// all services.
    /// </remarks>
    public sealed class GenericResponseModel<TModel> : GenericResponseModel where TModel : new()
    {
        public GenericResponseModel()
        { }

        /// <summary>
        /// Gets or sets the data that contains the content of the response.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public TModel Data { get; set; }
    }

    /// <summary>
    /// Represents a generic model that holds various information messages along with .NET primitive
    /// result.
    /// </summary>
    /// <typeparam name="TPrimitive">The type of the primitive.</typeparam>
    /// <remarks>
    /// Used as a ViewModel when being returned from services. Any change will alter the contract of
    /// all services.
    /// </remarks>
    public sealed class GenericResponsePrimitive<TPrimitive> : GenericResponseModel
        where TPrimitive : IConvertible, IComparable
    {
        internal GenericResponsePrimitive()
        {
            if (!(typeof(TPrimitive).IsPrimitive || (typeof(TPrimitive) == typeof(string)) ||
                  typeof(TPrimitive).IsEnum))
            {
                throw new InvalidCastException("TPrimitive is not a .NET primitive type.");
            }
        }

        /// <summary>
        /// Gets or sets the data that contains the content of the response.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public TPrimitive Data { get; set; }
    }
}
