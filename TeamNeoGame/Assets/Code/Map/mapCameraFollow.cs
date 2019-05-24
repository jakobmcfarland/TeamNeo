﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCameraFollow : MonoBehaviour
{
    public GameObject playerObject = null;
    Transform player = null;
    Transform camera = null;

    public Vector2 mapPositiveBounds;
    public Vector2 mapNegativeBounds;
    public float lerpSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObject)
        {
            player = playerObject.GetComponent<Transform>();
        }

        camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
            Vector3 newCam = Vector3.Lerp(camera.position, player.position, lerpSpeed * Time.deltaTime);
            newCam.z = camera.position.z;

            Mathf.Clamp( camera.position.x, mapNegativeBounds.x, mapPositiveBounds.x );
            Mathf.Clamp( camera.position.y, mapNegativeBounds.y, mapPositiveBounds.y );

            camera.position = newCam;
        }
    }
}
