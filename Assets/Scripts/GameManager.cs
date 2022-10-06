using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    [SerializeField] private HealthDisplay healthDisplay;
    [SerializeField] private int health = 3;
    [SerializeField] private AudioSource persistantPlayerAudio;
    [SerializeField] private SoAudioClip winAudioClips;
    [SerializeField] private SoAudioClip dealthAudioClips;
    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            healthDisplay.UpdateHealth(health);
        }
    }

    public void ProcessPlayerDeath()
    {
        health--;
        healthDisplay.UpdateHealth(health);
        PlayDeadSound();
        //SceneManager.LoadScene(GetCurrentBuildIndex());
        if(health == 0) { LoadMainMenu(); }
        else { LoadLevel(GetCurrentBuildIndex()); }
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        LoadLevel(nextSceneIndex);
        
        SceneManager.LoadScene(nextSceneIndex);
        DOTween.KillAll();
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        DOTween.KillAll();
    }

    public void LoadMainMenu()
    {
        LoadLevel(0);
        Destroy(gameObject);
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayWinSound()
    {
        persistantPlayerAudio.PlayOneShot(winAudioClips.GetAudioClip());
    }

    private void PlayDeadSound()
    {
        persistantPlayerAudio.PlayOneShot(dealthAudioClips.GetAudioClip());
    }
}
