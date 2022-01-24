using System;
using System.Collections.Generic;
using SampleResourceManagementApp.Localization.Dictionaries.DictionariesExtensions;
using SampleResourceManagementApp.Localization.LocalizationResources;

namespace SampleResourceManagementApp.Localization.Dictionaries
{
    public class LocalizationResourceDictionary: Dictionary<Type, LocalizationResource>
    {
        public LocalizationResource Add<TResource>(string defaultCultureName = null)
        {
            return Add(typeof(TResource), defaultCultureName);
        }

        public LocalizationResource Add(Type resourceType, string defaultCultureName = null)
        {
            if (ContainsKey(resourceType))
                throw new Exception("This resource is already added before: " + resourceType.AssemblyQualifiedName);

            return base[resourceType] = new LocalizationResource(resourceType, defaultCultureName);
        }

        public LocalizationResource Get<TResource>()
        {
            Type resourceType = typeof(TResource);
            return this.GetOrDefault(resourceType) ?? throw new Exception("Can not find a resource with given type: " + resourceType.AssemblyQualifiedName);
        }
    }
}
