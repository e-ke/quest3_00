using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public VideoOnRawImage video; // VideoOnRawImageの参照
    // Lights
    public CreateLights Lights_L;
    public CreateLights Lights_R;
    public CreateLights Lights_TR;
    public CreateLights Lights_TL;
    public CreateLights Lights_BR;
    public CreateLights Lights_BL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右コントローラー //////////////////////////////////////////
        if (OVRInput.GetDown(OVRInput.RawButton.A))  // simulator: B
        {
            Debug.Log("Aボタンを押した");
            video.PlayVideo();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Debug.Log("Bボタンを押した");
        }

        // 左コントローラー //////////////////////////////////////////
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("Xボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            Debug.Log("Yボタンを押した");
        }
        // if (OVRInput.GetDown(OVRInput.RawButton.Start))
        // {
        //     Debug.Log("左手メニューボタンを押した（オン・オフ不安定なので注意）");
        // }


        // if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        // {
        //     Debug.Log("右人差し指トリガーを押した");
        // }
        // if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        // {
        //     Debug.Log("右中指グリップを押した");
        // }
        // if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        // {
        //     Debug.Log("左人差し指トリガーを押した");
        // }
        // if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        // {
        //     Debug.Log("左中指グリップを押した");
        // }

        // 左スティック //////////////////////////////////////////
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp))
        {
            Debug.Log("左アナログスティックを上に倒した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown))
        {
            Debug.Log("左アナログスティックを下に倒した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft))
        {
            Debug.Log("左アナログスティックを左に倒した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight))
        {
            Debug.Log("左アナログスティックを右に倒した");
        }

        // 右スティック //////////////////////////////////////////
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp))
        {
            Debug.Log("右アナログスティックを上に倒した");
            // Lights_TR.run();
            // Lights_TL.run();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
        {
            Debug.Log("右アナログスティックを下に倒した");
            // Lights_BR.run();
            // Lights_BL.run();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            Debug.Log("右アナログスティックを左に倒した");
            // Lights_L.run();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            Debug.Log("右アナログスティックを右に倒した");
            // Lights_R.run();
        }
    }
}
