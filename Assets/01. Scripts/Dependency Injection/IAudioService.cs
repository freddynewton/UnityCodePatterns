/// <summary>
/// Interface for audio services to play sounds and music.
/// </summary>
public interface IAudioService
{
    /// <summary>
    /// Plays a sound by its name.
    /// </summary>
    /// <param name="soundName">The name of the sound to play.</param>
    void PlaySound(string soundName);

    /// <summary>
    /// Plays music by its name.
    /// </summary>
    /// <param name="musicName">The name of the music to play.</param>
    void PlayMusic(string musicName);
}
