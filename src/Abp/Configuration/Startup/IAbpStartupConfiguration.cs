﻿namespace Abp.Configuration.Startup
{
    /// <summary>
    /// Used to configure ABP and modules on startup.
    /// </summary>
    public interface IAbpStartupConfiguration : IDictionaryBasedConfig
    {
        /// <summary>
        /// Used to set localization configuration.
        /// </summary>
        IAbpLocalizationConfiguration Localization { get; }

        /// <summary>
        /// Gets/sets default connection string used by ORM module.
        /// It can be name of a connection string in application's config file or can be full connection string.
        /// </summary>
        string DefaultConnectionString { get; set; }

        /// <summary>
        /// Used to configure modules.
        /// Modules can write extension methods to <see cref="IAbpModuleConfigurations"/> to add module specific configurations.
        /// </summary>
        IAbpModuleConfigurations Modules { get; }
    }
}