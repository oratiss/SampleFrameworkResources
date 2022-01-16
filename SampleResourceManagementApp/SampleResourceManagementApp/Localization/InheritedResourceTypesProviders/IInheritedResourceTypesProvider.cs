using System;
using System.Diagnostics.CodeAnalysis;

namespace SampleResourceManagementApp.Localization.InheritedResourceTypesProviders
{
    public interface IInheritedResourceTypesProvider
    {
        Type[] GetInheritedResourceTypes();
    }
}
