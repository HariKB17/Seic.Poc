using System;

namespace Product.Domain.Common
{
    /// <summary>
    /// Represents a message class in order to hold various types of messages.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        public MessageType Type { get; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the message text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        /// <param name="type">Type of the message.</param>
        /// <param name="title">The title.</param>
        /// <param name="text">The message text.</param>
        public Message(MessageType type, string title, string text)
        {
            if (!Enum.IsDefined(typeof(MessageType), type)) throw new ArgumentOutOfRangeException(nameof(type));
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
            //if (!Enum.IsDefined(typeof(MessageDisplayType), type)) throw new ArgumentOutOfRangeException(nameof(displayType));

            Type = type;
            Title = title;
            Text = text;
        }
    }
}
