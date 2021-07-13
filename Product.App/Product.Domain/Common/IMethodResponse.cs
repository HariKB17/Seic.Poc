using System.Collections.Generic;

namespace Product.Domain.Common
{
    /// <summary>
    /// Interface for the return value of business layer methods that return no data.
    /// </summary>
    public interface IMethodResponse
    {
        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        IList<Message> Messages { get; }

        /// <summary>
        /// Adds the success message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="successMessage">The success message.</param>
        void AddSuccessMessage(string title, string successMessage);

        /// <summary>
        /// Adds the information message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="informationMessage">The information message.</param>
        void AddInformationMessage(string title, string informationMessage);

        /// <summary>
        /// Adds the warning message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="warningMessage">The warning message.</param>
        void AddWarningMessage(string title, string warningMessage);

        /// <summary>
        /// Adds the error message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="errorMessage">The error message.</param>
        void AddErrorMessage(string title, string errorMessage);

        /// <summary>
        /// Adds the validation message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="validationMessage">The validation message.</param>
        void AddValidationMessage(string title, string validationMessage);

        /// <summary>
        /// Merges the specified method response.
        /// </summary>
        /// <param name="methodResponse">The method response.</param>
        /// <param name="addErrorsAsInformationMessages">if set to <c>true</c> [add errors as information messages].</param>
        void Merge(IMethodResponse methodResponse, bool addErrorsAsInformationMessages = false);
    }

    /// <summary>
    /// Interface for the return value of business layer methods that return data.
    /// </summary>
    /// <typeparam name="T">The type of the data returned.</typeparam>
    public interface IMethodResponse<T> : IMethodResponse
    {
        T ReturnValue { get; set; }
    }
}
