using System;
using Microsoft.Extensions.FileProviders;
using SampleResourceManagementApp.Localization.Dictionaries;
using SampleResourceManagementApp.Localization.Json;

namespace SampleResourceManagementApp.Localization.VirtualFiles
{
    public class JsonVirtualFileLocalizationResourceContributor : VirtualFileLocalizationResourceContributorBase
    {
        public JsonVirtualFileLocalizationResourceContributor(string virtualPath):base(virtualPath)
        {
            
        }

        protected override bool CanParseFile(IFileInfo file)
        {
            return file.Name.EndsWith(".json", StringComparison.OrdinalIgnoreCase);
        }

        protected override ILocalizationDictionary CreateDictionaryFromFileContent(string jsonString)
        {
            return JsonLocalizationDictionaryBuilder.BuildFromJsonString(jsonString);
        }
    }
}
