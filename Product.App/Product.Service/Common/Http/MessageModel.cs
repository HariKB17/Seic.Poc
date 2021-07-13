using System;

namespace Product.Service.Common
{
    /// <summary>
    /// Represents a message set to a service caller.
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageModel" /> class.
        /// </summary>
        public MessageModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageModel"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <exception cref="System.ArgumentNullException">
        /// title
        /// or
        /// text
        /// </exception>
        public MessageModel(string title, string text)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
