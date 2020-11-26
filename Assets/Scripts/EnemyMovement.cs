using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.05f;
    private float changeTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (changeTime > 0)
        {
            transform.Translate(Vector3.forward * speed);
            changeTime -= Time.deltaTime;
        }
        else
        {
            ChangeDirection();
            changeTime = Random.Range(2.0f, 4.0f);
        }
    }

    void ChangeDirection()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }
}
