using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScores : MonoBehaviour
{
    public bool isInitializing;
    public NextCoinController nextCoinController;
    public CatchFallingCoin catchFallingCoin;

    private TextMeshPro textMeshPro;
    private string format;
    private float ellapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        format = textMeshPro.text;
        textMeshPro.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isInitializing) return;
        ellapsedTime += Time.deltaTime;
        if (Time.frameCount % 6 == 0)
        {
            textMeshPro.text = string.Format(format,
                ellapsedTime.ToString("0.000"),
                nextCoinController.inputedCoinCount * 100,
                catchFallingCoin.catchedCount * 100,
                (catchFallingCoin.catchedCount - nextCoinController.inputedCoinCount) * 100);
        }
    }
}
