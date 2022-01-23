namespace SampleResourceManagementApp.Settings
{
    public interface ISettingEncryptionService
    {
        string Encrypt(SettingDefinition settingDefinition, string plainValue);
        string Decrypt(SettingDefinition settingDefinition, string encryptedValue);
    }
}