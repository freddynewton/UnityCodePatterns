using VContainer;
using VContainer.Unity;

/// <summary>
/// GameInstaller is responsible for configuring dependency injection using VContainer.
/// </summary>
public class GameInstaller : LifetimeScope
{
    /// <summary>
    /// Configures the container with the necessary dependencies.
    /// </summary>
    /// <param name="builder">The container builder used to register dependencies.</param>
    protected override void Configure(IContainerBuilder builder)
    {
        /// Register IAudioService as a singleton instance of AudioService.
        builder.Register<IAudioService, AudioService>(Lifetime.Singleton);
    }
}
