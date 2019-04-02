using System;
using System.Collections.Generic;
using System.Text;
using Initium.Abstractions;

namespace Initium.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ScopedAttribute : Attribute, IAttribute
    {
    }
}
