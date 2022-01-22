using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleResourceManagementApp.Localization.Settings
{
    public class SettingProvider : ISettingProvider
    {
        protected ISettingDefinitionManager SettingDefinitionManager { get; }
        protected ISettingEncryptionService SettingEncryptionService { get; }
        protected ISettingValueProviderManager SettingValueProviderManager { get; }

        public SettingProvider(ISettingDefinitionManager settingDefinitionManager,
            ISettingEncryptionService settingEncryptionService,
            ISettingValueProviderManager settingValueProviderManager)
        {
            SettingDefinitionManager = settingDefinitionManager;
            SettingEncryptionService = settingEncryptionService;
            SettingValueProviderManager = settingValueProviderManager;
        }

        public Task<string> GetOrNullAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SettingValue>> GetAllAsync(string[] names)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SettingValue>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
