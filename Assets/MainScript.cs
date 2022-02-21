using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform container;

    public CatchFallingCoin catchFallingCoin;
    public ShowScores showScores;
    
    public TextMeshPro initializingText;
    public float initializingDuration = 6;
    private float currentInitializingDuration = 0;
    public bool isInitializing = true;
    private string initializingFormat;

    public int initialCoinCount = 100;
    private int createdCoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        initializingFormat = initializingText.text;
        initializingText.text = "";
        catchFallingCoin.isInitializing = isInitializing;
        showScores.isInitializing = isInitializing;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInitializing)
        {
            currentInitializingDuration += Time.deltaTime;
            if (Time.frameCount % 6 == 0)
            {
                initializingText.text = string.Format(
                    initializingFormat,
                    (initializingDuration - currentInitializingDuration).ToString("0"));
            }
            if (currentInitializingDuration > initializingDuration)
            {
                isInitializing = false;
                catchFallingCoin.isInitializing = false;
                showScores.isInitializing = false;
                Destroy(initializingText.gameObject);
            }
        }

        if (createdCoinCount < initialCoinCount)
        {
            var x = Random.Range(-3f, 3f);
            var z = Random.Range(-3f, 3f);
            var pos = new Vector3(x, 10, z);
            Instantiate(coinPrefab, pos, Quaternion.identity, container);
            createdCoinCount++;
        }
    }
}
