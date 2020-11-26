using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Variables
    public GameObject player;
    private Vector3 offset = new Vector3(0f, 7.5f, -7f);

    // Update is called once per frame
    void Update()
    {
        // Offset the camera to follow the player
        transform.position = player.transform.position + offset;
    }
}

