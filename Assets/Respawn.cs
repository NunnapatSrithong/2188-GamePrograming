using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float waitingSeconds;
    [SerializeField] private GameObject respawnItem;

    public void RespawnItem()
    {
        StartCoroutine(SuperRespawn());
    }
    
    private IEnumerator SuperRespawn()
    {
        yield return new WaitForSeconds(waitingSeconds);
        respawnItem.SetActive(true);
    }
 
}
