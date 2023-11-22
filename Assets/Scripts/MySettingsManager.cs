using System;
using UnityEngine;

public class MySettingsManager : MonoBehaviour
{
    // 起動時のパススルー状態を指定
    [SerializeField] private Boolean isPassthroughEnableOnStartup = false;
    public Camera CenterEyeCam;
    void Start()
    {
        // FFRを「Low」レベルに設定
        OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.Low;
        // 起動時のパススルー状態を設定
        OVRManager.instance.isInsightPassthroughEnabled = isPassthroughEnableOnStartup;
        if (isPassthroughEnableOnStartup)
        {
            CenterEyeCam.clearFlags = CameraClearFlags.Color;
            // RenderSettings.skybox = null;
        }
        else
        {
            CenterEyeCam.clearFlags = CameraClearFlags.Skybox;
        }
    }
}
