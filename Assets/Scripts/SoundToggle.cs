using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource bgMusic;   // assign your background music AudioSource

    [Header("UI")]
    public Button soundButton;    // assign your UI button
    public Image iconImage;       // assign the Image on the button
    public Sprite iconOn;         // speaker ON icon
    public Sprite iconOff;        // speaker OFF icon

    private bool isMuted;

    void Start()
    {
        // Load saved mute state
        isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        ApplyMute();
        UpdateButtonUI();

        // Add button click listener
        soundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        // Flip state
        isMuted = !isMuted;

        // Apply mute
        ApplyMute();

        // Save preference
        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        // Update button
        UpdateButtonUI();
    }

    void ApplyMute()
    {
        if (bgMusic != null)
        {
            bgMusic.mute = isMuted;   // true = silent, false = play normally
        }
    }

    void UpdateButtonUI()
    {
        if (iconImage != null)
        {
            iconImage.sprite = isMuted ? iconOff : iconOn;
        }
    }
}
