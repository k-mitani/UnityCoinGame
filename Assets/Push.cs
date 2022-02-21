using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private bool isPushing = true;
    public float pushMaxZ;
    public float pullMinZ;
    public float speed;
    public float waitTime;
    private float currentWaitTime;
    private bool isWaiting = false;
    private new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0, 0, speed * (isPushing ? 1 : -1));
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            currentWaitTime += Time.deltaTime;
            if (currentWaitTime > waitTime)
            {
                isWaiting = false;
                rigidbody.velocity = new Vector3(0, 0, speed * (isPushing ? 1 : -1));
            }
        }
        else if (isPushing)
        {
            if (transform.position.z >= pushMaxZ)
            {
                isPushing = false;
                isWaiting = true;
                currentWaitTime = 0;
                rigidbody.velocity = Vector3.zero;
            }
        }
        else
        {
            if (transform.position.z <= pullMinZ)
            {
                isPushing = true;
                isWaiting = true;
                currentWaitTime = 0;
                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}
