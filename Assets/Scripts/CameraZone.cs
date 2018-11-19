using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{

    CameraFollow follow;

    public Vector2 zoneOffset;

    // Use this for initialization
    void Start()
    {
        follow = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow.ChangeOffset(zoneOffset);
    }

}
