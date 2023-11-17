using UnityEngine;

public class MySettingsManager : MonoBehaviour
{
    void Start()
    {
        // FFRを「Low」レベルに設定
        OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.Low;
    }
}
