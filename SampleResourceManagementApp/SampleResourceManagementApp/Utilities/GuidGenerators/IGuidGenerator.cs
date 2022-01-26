using System;

namespace SampleResourceManagementApp.Utilities.GuidGenerators
{
    /// <summary>
    /// Used to generate Ids.
    /// </summary>
    public interface IGuidGenerator
    {
        /// <summary>
        /// Creates a new <see cref="Guid"/>.
        /// </summary>
        Guid Create();
    }
}
