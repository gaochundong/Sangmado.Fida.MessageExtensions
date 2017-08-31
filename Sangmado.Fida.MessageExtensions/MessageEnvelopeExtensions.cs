using Sangmado.Fida.MessageEncoding;

namespace Sangmado.Fida.Messages
{
    public static class MessageEnvelopeExtensions
    {
        public static MessageEnvelope<T> Instantiate<T>(this MessageEnvelope envelope, IMessageDecoder decoder)
        {
            var message = envelope.ConvertTo<T>();
            message.Message = decoder.DecodeMessage<T>(envelope.Body);
            return message;
        }

        public static MessageEnvelope Marshal<T>(this MessageEnvelope<T> envelope, IMessageEncoder encoder)
        {
            var message = envelope.ConvertToNonGeneric();
            message.Body = encoder.EncodeMessage(envelope.Message);
            return message;
        }

        public static byte[] ToBytes(this MessageEnvelope envelope, IMessageEncoder encoder)
        {
            return encoder.EncodeMessage(envelope);
        }

        public static byte[] ToBytes<T>(this MessageEnvelope<T> envelope, IMessageEncoder encoder)
        {
            return ToBytes(envelope.Marshal(encoder), encoder);
        }
    }
}
