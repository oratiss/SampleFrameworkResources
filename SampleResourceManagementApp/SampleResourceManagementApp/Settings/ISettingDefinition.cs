using System.Collections.Generic;
using SampleResourceManagementApp.Localization.LocalizableStrings;

namespace SampleResourceManagementApp.Settings
{
    public interface ISettingDefinition
    {
        /// <summary>
        /// Unique name of the setting.
        /// </summary>
        string Name { get; }

        ILocalizableString? DisplayName { get; set; }
        ILocalizableString? Description { get; set; }

        /// <summary>
        /// Default value of the setting.
        /// </summary>
        string? DefaultValue { get; set; }

        /// <summary>
        /// Can clients see this setting and it's value.
        /// It maybe dangerous for some settings to be visible to clients (such as an email server password).
        /// Default: false.
        /// </summary>
        bool IsVisibleToClients { get; set; }

        /// <summary>
        /// A list of allowed providers to get/set value of this setting.
        /// An empty list indicates that all providers are allowed.
        /// </summary>
        List<string> Providers { get; } //TODO: Rename to AllowedProviders

        /// <summary>
        /// Is this setting inherited from parent scopes.
        /// Default: True.
        /// </summary>
        bool IsInherited { get; set; }

        /// <summary>
        /// Can be used to get/set custom properties for this setting definition.
        /// </summary>
        Dictionary<string, object> Properties { get; }

        /// <summary>
        /// Is this setting stored as encrypted in the data source.
        /// Default: False.
        /// </summary>
        bool IsEncrypted { get; set; }

        /// <summary>
        /// Sets a property in the <see cref="SettingDefinition.Properties"/> dictionary.
        /// This is a shortcut for nested calls on this object.
        /// </summary>
        SettingDefinition WithProperty(string key, object value);

        /// <summary>
        /// Sets a property in the <see cref="SettingDefinition.Properties"/> dictionary.
        /// This is a shortcut for nested calls on this object.
        /// </summary>
        SettingDefinition WithProviders(params string[] providers);
    }
}