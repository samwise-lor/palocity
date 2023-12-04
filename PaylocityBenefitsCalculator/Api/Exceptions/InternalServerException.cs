using System.Runtime.Serialization;

namespace Api.Exceptions
{
    [Serializable]
    public class InternalServerException : Exception, ISerializable
    {
        public InternalServerException(string message) : base(message) { }

        private InternalServerException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
