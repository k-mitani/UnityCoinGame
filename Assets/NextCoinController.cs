using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCoinController : MonoBehaviour
{
    public float maxX = 2.85f;
    public float minX = -1.85f;
    public float speed = 3f;
    public GameObject coinPrefab;
    public Transform container;
    public Vector3 coinPositionOffset;
    public Vector3 coinRotation;
    private float coinInsertionInterval = 1;
    private float coinInsertionIntervalCurrent = 0;
    private bool isInCoinInsertionInterval = false;
    public int inputedCoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = -Input.GetAxis("Horizontal");
        var xDistance = Time.deltaTime * speed *  horizontal;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + xDistance, minX, maxX),
            transform.position.y,
            transform.position.z);
        
        if (isInCoinInsertionInterval)
        {
            coinInsertionIntervalCurrent += Time.deltaTime;
            if (coinInsertionIntervalCurrent >= coinInsertionInterval)
            {
                isInCoinInsertionInterval = false;
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            var newCoin = Instantiate(
                coinPrefab,
                transform.position + coinPositionOffset,
                Quaternion.identity,
                container);
            newCoin.transform.Rotate(coinRotation);
            coinInsertionIntervalCurrent = 0;
            isInCoinInsertionInterval = true;
            inputedCoinCount++;
        }
    }
}
