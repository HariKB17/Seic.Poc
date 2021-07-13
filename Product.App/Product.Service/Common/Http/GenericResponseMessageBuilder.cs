using System;
using Product.Domain.Common;

namespace Product.Service.Common.Http
{
    public static class GenericResponseMessageBuilder
    {
        /// <summary>
        /// Extension Method to copy Messages to Model instances
        /// </summary>
        /// <param name="genericResponseModel">Instance of GenericResponseModel</param>
        /// <param name="methodResponse">Instance of Method Response</param>
        public static void Build(this GenericResponseModel genericResponseModel, IMethodResponse methodResponse)
        {
            if (methodResponse == null) throw new ArgumentNullException(nameof(methodResponse));

            foreach (var message in methodResponse.Messages)
                AddMessageToResponseModel(genericResponseModel, message);
        }

        /// <summary>
        /// Extension Method to copy Messages to Model instances
        /// </summary>
        /// <typeparam name="TModel">Model of primitive or reference types</typeparam>
        /// <param name="genericResponseModel"></param>
        /// <param name="methodResponse"></param>
        public static void Build<TModel>(this GenericResponseModel<TModel> genericResponseModel, IMethodResponse methodResponse) where TModel : IConvertible, IComparable, new()
        {
            if (methodResponse == null) throw new ArgumentNullException(nameof(methodResponse));

            foreach (var message in methodResponse.Messages)
                AddMessageToResponseModel(genericResponseModel, message);
        }

        /// <summary>
        /// Add Message to Model instances
        /// </summary>
        /// <param name="genericResponseModel"></param>
        /// <param name="message"></param>
        private static void AddMessageToResponseModel(GenericResponseModel genericResponseModel,
            Message message)
        {
            var messageModel = Map(message);

            switch (message.Type)
            {
                case MessageType.Authorization:
                case MessageType.Validation:
                case MessageType.Error:
                    genericResponseModel.ErrorMessages.Add(messageModel);
                    break;
                case MessageType.Warning:
                    genericResponseModel.WarningMessages.Add(messageModel);
                    break;
                case MessageType.Information:
                    genericResponseModel.InformationMessages.Add(messageModel);
                    break;
                case MessageType.Success:
                    genericResponseModel.SuccessMessages.Add(messageModel);
                    break;
                default:
                    System.Diagnostics.Debug.Assert(false, "Unhandled message type.");
                    throw new ArgumentException(nameof(message.Type));
            }
        }

        /// <summary>
        /// Maps the specified <see cref="Message"/> to a new <see cref="MessageModel"/>.
        /// </summary>
        /// <param name="from">The <see cref="Message"/> to map from.</param>
        /// <returns>The mapped <see cref="MessageModel"/>.</returns>
        private static MessageModel Map(Message from)
        {
            if (string.IsNullOrEmpty(from.Title)) throw new ArgumentNullException(nameof(from.Title));
            if (string.IsNullOrEmpty(from.Text)) throw new ArgumentNullException(nameof(from.Text));

            return new MessageModel
            {
                Title = from.Title,
                Text = from.Text
            };
        }
    }
}
