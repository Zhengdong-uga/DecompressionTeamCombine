using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform playerRig;         // XR Rig (ex. OVRCameraRig)
    public Transform teleportTarget;    // 목적지 위치 오브젝트

    public void Teleport()
    {
        if (playerRig != null && teleportTarget != null)
        {
            playerRig.position = teleportTarget.position;
        }
    }
}
