using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

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

    private IEnumerator DelayLoadLevel(int levelindex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelindex);
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void LoadLevel(int levelIndex)
    {
        //SceneManager.LoadScene(levelIndex);
        StartCoroutine(DelayLoadLevel(levelIndex));
        DOTween.KillAll();
    }

    public void ProcessPlayerDeath()
    {
        health--;
        healthDisplay.UpdateHealth(health);
        PlayDeadSound();
        //SceneManager.LoadScene(GetCurrentBuildIndex());
        if (health == 0) { LoadMainMenu(); }
        else { LoadLevel(GetCurrentBuildIndex()); }
    }

    public void LoadMainMenu()
    {
        LoadLevel(0);
        StartCoroutine(DelayDestroy());
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
