using System.Collections;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    // This script is to handle the respawning of the collectible as a disabled gameObject cannot run any methods or coroutines on its own.
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject collectibleGameObject;
    [SerializeField] private ParticleSystem collectItem;
    [SerializeField] private ParticleSystem restoreItem;

    [Header("Collectible Settings")]
    [SerializeField] private float respawnTime = 4f;

    private IEnumerator RespawnCollectible()
    {
        collectItem.Play();
        yield return new WaitForSeconds(respawnTime);
        SetOutlineSpriteActive(false);
        collectibleGameObject.SetActive(true);

        restoreItem.Play();
        yield return new WaitForSeconds(1);
        collectibleGameObject.SetActive(true);
    }

    private void SetOutlineSpriteActive(bool state)
    {
        spriteRenderer.enabled = state;
    }

    public void SetOutlineSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    
    public void StartRespawningCountdown() // This method is to let other script trigger the respawn countdown, and let this script handle the coroutine.
    {
        SetOutlineSpriteActive(true);
        StartCoroutine(RespawnCollectible());
    }
}
