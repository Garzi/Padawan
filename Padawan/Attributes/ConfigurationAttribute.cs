using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Abstractions;

namespace Padawan.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ConfigurationAttribute : Attribute, IAttribute
    {
        public string Section { get; }

        public ConfigurationAttribute(string section)
        {
            Section = section;
        }
    }
}
