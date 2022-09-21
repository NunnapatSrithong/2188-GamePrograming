using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Collectibles")]
public class SoCollectible : ScriptableObject
{
    [SerializeField] private string collectibleitem;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool isRespawnable;

    [SerializeField] private CollectibleType collectibleType;

    public string GetCollectible()
    {
        return collectibleitem;
    }
}


