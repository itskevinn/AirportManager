﻿using System.Runtime.Serialization;

namespace AirportGateway.App.Exceptions;
[Serializable]
public class MethodWithNotRolesAdmittedException : Exception
{
    public MethodWithNotRolesAdmittedException()
    {
    }

    protected MethodWithNotRolesAdmittedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MethodWithNotRolesAdmittedException(string? message) : base(message)
    {
    }

    public MethodWithNotRolesAdmittedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}