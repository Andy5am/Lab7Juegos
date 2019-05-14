using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Vector2 start;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, Time.deltaTime * 50, 0);
        transform.position = start + new Vector2(Mathf.Sin(Time.time) * 4,0);
    }
}
