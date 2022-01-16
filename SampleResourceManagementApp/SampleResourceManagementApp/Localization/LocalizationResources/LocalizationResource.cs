using SampleResourceManagementApp.Localization.Collections.CollectionExtensions;
using SampleResourceManagementApp.Localization.InheritedResourceTypesProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using SampleResourceManagementApp.Localization.VirtualFiles;
using SampleResourceManagementApp.Utilities.Assertions;

namespace SampleResourceManagementApp.Localization.LocalizationResources
{
    public class LocalizationResource
    {
        public Type ResourceType
        {
            get;
        }

        public string ResourceName => LocalizationResourceNameAttribute.GetName(ResourceType);

        public string DefaultCultureName { get; set; }

        public LocalizationResourceContributorList Contributors { get; }

        public List<Type> BaseResourceTypes { get; }

        public LocalizationResource(Type resourceType, string defaultCultureName = null, ILocalizationResourceContributor initialContributor = null)
        {
            ResourceType = LocalizationAssertion.NotNull(resourceType, "resourceType");
            DefaultCultureName = defaultCultureName;
            BaseResourceTypes = new List<Type>();
            Contributors = new LocalizationResourceContributorList();
            if (initialContributor != null)
                Contributors.Add(initialContributor);

            AddBaseResourceTypes();
        }

        protected virtual void AddBaseResourceTypes()
        {
            var descriptors = ResourceType.GetCustomAttributes(true)
                                                                            .OfType<IInheritedResourceTypesProvider>();

            foreach (var descriptor in descriptors)
                foreach (var baseResourceType in descriptor.GetInheritedResourceTypes())
                    BaseResourceTypes.AddIfNotContains(baseResourceType);
            
        }
    }
}
