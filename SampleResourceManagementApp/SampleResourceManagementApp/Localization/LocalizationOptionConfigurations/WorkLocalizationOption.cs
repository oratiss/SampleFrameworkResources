using System;
using System.Collections.Generic;
using SampleResourceManagementApp.Localization.Collections;
using SampleResourceManagementApp.Localization.Dictionaries;
using SampleResourceManagementApp.Localization.LanguageInfos;
using SampleResourceManagementApp.Localization.NameValues;
using SampleResourceManagementApp.Localization.VirtualFiles;

namespace SampleResourceManagementApp.Localization.LocalizationOptionConfigurations
{
    public class WorkLocalizationOption
    {
        public LocalizationResourceDictionary Resources { get; }

        /// <summary>
        /// Used as the default resource when resource was not specified on a localization operation.
        /// </summary>
        public Type DefaultResourceType { get; set; }

        public ITypeList<ILocalizationResourceContributor> GlobalContributors { get; }

        public List<LanguageInfo> Languages { get; }

        public Dictionary<string, List<NameValue>> LanguagesMap { get; }

        public Dictionary<string, List<NameValue>> LanguageFilesMap { get; }

        public WorkLocalizationOption()
        {
            Resources = new LocalizationResourceDictionary();
            GlobalContributors = new TypeList<ILocalizationResourceContributor>();
            Languages = new List<LanguageInfo>();
            LanguagesMap = new Dictionary<string, List<NameValue>>();
            LanguageFilesMap = new Dictionary<string, List<NameValue>>();
        }
    }
}
