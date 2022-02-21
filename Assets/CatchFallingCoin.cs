using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFallingCoin : MonoBehaviour
{
    public bool isInitializing;
    public int catchedCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var coin = other.gameObject.transform.parent.gameObject;
        if (coin.activeSelf)
        {
            coin.SetActive(false);
            if (!isInitializing) catchedCount++;
            Debug.Log(coin.GetInstanceID() + " " + catchedCount.ToString());
            Destroy(coin);
        }
    }
}
