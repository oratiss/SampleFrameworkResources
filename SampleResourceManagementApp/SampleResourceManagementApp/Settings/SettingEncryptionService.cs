using SampleResourceManagementApp.EncryptionServices;

namespace SampleResourceManagementApp.Settings
{
    public class SettingEncryptionService : ISettingEncryptionService
    {
        protected IStringEncryptionService StringEncryptionService { get; }

        public SettingEncryptionService(IStringEncryptionService stringEncryptionService)
        {
            StringEncryptionService = stringEncryptionService;
        }

        public virtual string Encrypt(SettingDefinition settingDefinition, string plainValue)
        {
            return string.IsNullOrEmpty(plainValue) ? plainValue : StringEncryptionService.Encrypt(plainValue);
        }

        public virtual string Decrypt(SettingDefinition settingDefinition, string encryptedValue)
        {
            return string.IsNullOrEmpty(encryptedValue) ? encryptedValue : StringEncryptionService.Decrypt(encryptedValue);
        }
    }
}