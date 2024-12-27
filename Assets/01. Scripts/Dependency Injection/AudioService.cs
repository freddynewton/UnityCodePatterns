using UnityEngine;

/// <summary>
/// Service responsible for handling audio playback.
/// </summary>
public class AudioService : IAudioService
{
    /// <summary>
    /// Plays a sound effect.
    /// </summary>
    /// <param name="soundName">The name of the sound to play.</param>
    public void PlaySound(string soundName)
    {
        Debug.Log($"Playing sound: {soundName}");
    }

    /// <summary>
    /// Plays background music.
    /// </summary>
    /// <param name="musicName">The name of the music to play.</param>
    public void PlayMusic(string musicName)
    {
        Debug.Log($"Playing music: {musicName}");
    }
}
