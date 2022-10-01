using UnityEngine;
using DG.Tweening;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private CollectibleSpawner collectibleSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SOCollectibles collectibleObject;
    [SerializeField] private GameObject endPoint;
    
    private CollectibleType _collectibleType;
    private bool _isRespawnable;

    private void Start()
    {
        SetCollectible();

        if (endPoint != null)
        {
            transform.DOMove(endPoint.transform.position, 1f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
        }
    }

    public CollectibleType GetCollectibleInfoOnContact()
    {
        gameObject.SetActive(false);

        if (_isRespawnable)
        {
            collectibleSpawner.StartRespawningCountdown();
        }

        return _collectibleType;

    }
    
    private void SetCollectible()
    {
        collectibleSpawner.SetOutlineSprite(collectibleObject.GetOutlineSprite());
        spriteRenderer.sprite = collectibleObject.GetSprite();
        _collectibleType = collectibleObject.GetCollectibleType();
        _isRespawnable = collectibleObject.GetRespawnable();
    }

    
}
