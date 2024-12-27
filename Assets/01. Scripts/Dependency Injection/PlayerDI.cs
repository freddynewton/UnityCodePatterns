using UnityEngine;
using VContainer;

/// <summary>
/// Player class that demonstrates dependency injection using VContainer.
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// The audio service used to play sounds.
    /// </summary>
    private IAudioService _audioService;

    /// <summary>
    /// Constructor for dependency injection.
    /// </summary>
    /// <param name="audioService">The audio service to be injected.</param>
    [Inject]
    public void Construct(IAudioService audioService)
    {
        _audioService = audioService;
    }

    /// <summary>
    /// Method called when the player jumps.
    /// </summary>
    private void OnJump()
    {
        _audioService.PlaySound("JumpSound");
    }
}
