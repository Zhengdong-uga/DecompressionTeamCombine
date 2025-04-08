using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToCoordinates : MonoBehaviour
{
    public Transform xrRig;   // OVRCameraRig 넣기
    public float targetX = 0f;
    public float targetY = 0f;
    public float targetZ = 0f;

    public void Teleport()
    {
        if (xrRig != null)
        {
            xrRig.position = new Vector3(targetX, targetY, targetZ);
        }
        else
        {
            Debug.LogWarning("XR Rig is not assigned!");
        }
    }
}

