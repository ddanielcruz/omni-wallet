using System;
using System.Runtime.Serialization;
using OmniWallet.Api.Dtos;

namespace OmniWallet.Api.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public ResponseDto Response => new ResponseDto(Message);
        
        public AppException()
        {
            
        }

        public AppException(string message) : base(message)
        {
            
        }

        public AppException(string message, Exception inner) : base(message, inner)
        {
            
        }

        protected AppException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            
        }
    }
}