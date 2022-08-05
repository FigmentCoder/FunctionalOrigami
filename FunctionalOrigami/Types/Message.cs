using FunctionalOrigami.Extensions;

namespace FunctionalOrigami.Types
{
    internal class Message
    {
        public static Message New(string value)
            => value.IsNull()
                ? Empty
                : new Message(value);

        public static Message Empty
            = New(string.Empty);

        private Message(string value)
            => Value = value;

        private readonly string Value;

        public static bool IsNullOrEmpty(Message message)
            => message.IsNull() || message.Equals(Empty);

        public static implicit operator Message(string value)
            => New(value);

        public static implicit operator string(Message message)
            => message.IsNull()
                ? string.Empty
                : message.Value;

        public override string ToString()
            => Value;
    }

    internal static class MessageConstructor
    {
        public static Message Message(string value)
            => Types.Message.New(value);
    }
}