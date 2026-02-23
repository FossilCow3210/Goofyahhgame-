using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineCamera cam1;
    public CinemachineCamera cam2;
    public CinemachineCamera cam3;
    public CinemachineCamera TankCam;
    public CinemachineCamera TankCam2;
    

    public void Switch1()
    {
        CameraManager.SwitchCamera(cam1);
    }

    public void Switch2()
    {
        CameraManager.SwitchCamera(cam2);
    }
    
    public void Switch3()
    {
        CameraManager.SwitchCamera(cam3);
    }
    public void SwitchTankCam()
    {
        CameraManager.SwitchCamera(TankCam);
    }

    public void SwitchTankCam2()
    {
        CameraManager.SwitchCamera(TankCam2);
    }
}
