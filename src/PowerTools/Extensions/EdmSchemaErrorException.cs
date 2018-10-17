﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Runtime.Serialization;
using Microsoft.DbContextPackage.Utilities;

namespace Microsoft.DbContextPackage.Extensions
{
    [Serializable]
    public class EdmSchemaErrorException : Exception
    {
        public EdmSchemaErrorException()
        {
        }

        public EdmSchemaErrorException(string message)
            : base(message)
        {
        }

        public EdmSchemaErrorException(string message, IEnumerable<EdmSchemaError> errors)
            : base(message)
        {
            Check.NotNull(errors, nameof(errors));

            Errors = errors;
        }

        public EdmSchemaErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected EdmSchemaErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Check.NotNull(info, nameof(info));

            Errors = (IEnumerable<EdmSchemaError>) info.GetValue("Errors", typeof(IEnumerable<EdmSchemaError>));
        }

        public IEnumerable<EdmSchemaError> Errors { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Check.NotNull(info, nameof(info));

            info.AddValue("Errors", Errors);

            base.GetObjectData(info, context);
        }
    }
}