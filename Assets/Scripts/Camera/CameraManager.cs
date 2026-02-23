using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static List<CinemachineCamera> cameras = new List<CinemachineCamera>();

    public static CinemachineCamera ActiveCamera;

    public static void SwitchCamera(CinemachineCamera newCamera)
    {
        if (ActiveCamera != null)
        {
           ActiveCamera.Priority = 1; 
        }
        ActiveCamera = newCamera;
        newCamera.Priority = 10;
    }

    public static void Register(CinemachineCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineCamera camera)
    {
        cameras.Remove(camera);
    }
}
