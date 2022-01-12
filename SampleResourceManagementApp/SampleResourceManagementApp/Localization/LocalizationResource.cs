using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleResourceManagementApp.Localization
{
    public class LocalizationResource
    {
        public Type ResourceType
        {
            get;
        }

        public string ResourceName => LocalizationResourceNameAttribute.GetName(ResourceType);

        public string DefaultCultureName
        {
            get;
            set;
        }

        public LocalizationResourceContributorList Contributors
        {
            get;
        }

        public List<Type> BaseResourceTypes
        {
            get;
        }

        public LocalizationResource(Type resourceType, string defaultCultureName = null, ILocalizationResourceContributor initialContributor = null)
        {
            ResourceType = Check.NotNull(resourceType, "resourceType");
            DefaultCultureName = defaultCultureName;
            BaseResourceTypes = new List<Type>();
            Contributors = new LocalizationResourceContributorList();
            if (initialContributor != null)
            {
                Contributors.Add(initialContributor);
            }

            AddBaseResourceTypes();
        }

        protected virtual void AddBaseResourceTypes()
        {
            foreach (IInheritedResourceTypesProvider item2 in ResourceType.GetCustomAttributes(inherit: true).OfType<IInheritedResourceTypesProvider>())
            {
                Type[] inheritedResourceTypes = item2.GetInheritedResourceTypes();
                foreach (Type item in inheritedResourceTypes)
                {
                    BaseResourceTypes.AddIfNotContains(item);
                }
            }
        }
    }


    public class LocalizationResourceNameAttribute : Attribute
    {
        public string Name { get; }

        public LocalizationResourceNameAttribute(string name) => Name = name;

        public static LocalizationResourceNameAttribute GetOrNull(Type resourceType)
        {
            return resourceType.GetCustomAttributes(inherit: true).OfType<LocalizationResourceNameAttribute>().FirstOrDefault();
        }

        public static string GetName(Type resourceType)
        {
            return GetOrNull(resourceType)?.Name ?? resourceType.FullName;
        }
    }
}
