using System.Collections.Generic;

namespace Product.Domain.Common
{
    /// <summary>
    /// A response from a business layer method that returns no data.
    /// </summary>
    /// <seealso cref="Product.Domain.Common.IMethodResponse" />
    public class MethodResponse : IMethodResponse
    {
        /// <summary>
        /// Gets the messages.
        /// </summary>
        public IList<Message> Messages { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodResponse"/> class.
        /// </summary>
        public MethodResponse()
        {
            Messages = new List<Message>();
        }

        /// <summary>
        /// Adds a success message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="successMessage">The success message.</param>
        public void AddSuccessMessage(string title, string successMessage)
        {
            AddMessage(new Message(MessageType.Success, title, successMessage));
        }

        /// <summary>
        /// Adds an information message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="informationMessage">The information message.</param>
        public void AddInformationMessage(string title, string informationMessage)
        {
            AddMessage(new Message(MessageType.Information, title, informationMessage));
        }

        /// <summary>
        /// Adds a warning message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="warningMessage">The warning message.</param>
        public void AddWarningMessage(string title, string warningMessage)
        {
            AddMessage(new Message(MessageType.Warning, title, warningMessage));
        }

        /// <summary>
        /// Adds an error message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="errorMessage">The error message.</param>
        public void AddErrorMessage(string title, string errorMessage)
        {
            AddMessage(new Message(MessageType.Error, title, errorMessage));
        }

        /// <summary>
        /// Adds a validation message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="validationMessage">The validation message.</param>
        public void AddValidationMessage(string title, string validationMessage)
        {
            AddMessage(new Message(MessageType.Validation, title, validationMessage));
        }

        /// <summary>
        /// Merges all of the <see cref="Message"/> instances from the specified <see cref="IMethodResponse.Common.IMethodResponse"/>
        /// to this instance. If the addErrorsAsInformationMessages flag is set; Authorization, Validation,
        /// and Error messages are converted to Information messages when copied.
        /// </summary>
        /// <param name="methodResponse">The method response.</param>
        /// <param name="addErrorsAsInformationMessages">if set to <c>true</c> convert Authorization,
        /// Validation, and Error messages to Information messages.</param>
        public void Merge(IMethodResponse methodResponse, bool addErrorsAsInformationMessages = false)
        {
            foreach (var message in methodResponse.Messages)
            {
                if (addErrorsAsInformationMessages &&
                    (message.Type == MessageType.Authorization) || (message.Type == MessageType.Validation) ||
                    (message.Type == MessageType.Error))
                {
                    AddMessage(new Message(MessageType.Information, message.Title, message.Text));
                }
                else
                {
                    AddMessage(message);
                }
            }
        }

        private void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }

    /// <summary>
    /// Class for returns from business layers that return data.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <seealso cref="Product.Domain.Common.IMethodResponse" />
    public class MethodResponse<T> : MethodResponse, IMethodResponse<T>
    {
        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        public T ReturnValue { get; set; }
    }
}
