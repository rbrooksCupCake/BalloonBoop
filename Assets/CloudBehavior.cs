using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    public const float MaxXValue = 4f;
    public Transform MyTransform;
    public float Speed;

    private void Awake()
    {
        Speed = Random.Range(.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(MyTransform.position.x<MaxXValue)
        {
            MyTransform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
            MyTransform.position = new Vector3(-4f, Random.Range(-4, 4f));
        }

    }
}
