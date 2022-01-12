using System;
using System.Collections.Generic;

namespace SampleResourceManagementApp.Dictionaries
{
    public class LocalizationResourceDictionary: Dictionary<Type, LocalizationResource>
    {
        public LocalizationResource Add<TResouce>(string defaultCultureName = null)
        {
            return Add(typeof(TResouce), defaultCultureName);
        }

        public LocalizationResource Add(Type resourceType, string defaultCultureName = null)
        {
            if (ContainsKey(resourceType))
            {
                throw new AbpException("This resource is already added before: " + resourceType.AssemblyQualifiedName);
            }

            return base[resourceType] = new LocalizationResource(resourceType, defaultCultureName);
        }

        public LocalizationResource Get<TResource>()
        {
            Type typeFromHandle = typeof(TResource);
            return this.GetOrDefault(typeFromHandle) ?? throw new AbpException("Can not find a resource with given type: " + typeFromHandle.AssemblyQualifiedName);
        }
    }
}
