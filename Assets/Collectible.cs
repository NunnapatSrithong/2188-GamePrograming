using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public itemcollectible color;
    [SerializeField] private SoCollectible soCollectible;
    [SerializeField] private Respawn respawn;

     private void Start()
    {
        Debug.Log(soCollectible.GetCollectible());
    }
    private void OnDisable()
    {
        respawn.RespawnItem();
    }
}
