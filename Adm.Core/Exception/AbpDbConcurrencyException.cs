﻿using System.Runtime.Serialization;

namespace Adm.Core.Exception
{
    [Serializable]
    public class AbpDbConcurrencyException : BaseException
    {
        /// <summary>
        /// Creates a new <see cref="AbpDbConcurrencyException"/> object.
        /// </summary>
        public AbpDbConcurrencyException()
        { }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        public AbpDbConcurrencyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }

        /// <summary>
        /// Creates a new <see cref="AbpDbConcurrencyException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AbpDbConcurrencyException(string message)
            : base(message)
        { }

        /// <summary>
        /// Creates a new <see cref="AbpDbConcurrencyException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AbpDbConcurrencyException(string message, System.Exception innerException)
            : base(message, innerException)
        { }
    }
}