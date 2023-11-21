using System;
using UnityEngine;

public class MySettingsManager : MonoBehaviour
{
    // 起動時のパススルー状態を指定
    [SerializeField] private Boolean isPassthroughEnableOnStartup = false;
    void Start()
    {
        // FFRを「Low」レベルに設定
        OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.Low;
        // 起動時のパススルー状態を設定
        OVRManager.instance.isInsightPassthroughEnabled = isPassthroughEnableOnStartup;
        if (isPassthroughEnableOnStartup)
        {
            RenderSettings.skybox = null;
        }
    }
}
