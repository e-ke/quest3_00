using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public VideoOnRawImage video; // VideoOnRawImageの参照
    public GameObject image; // Imageの参照
    // Lights
    public CreateLights Lights_L;
    public CreateLights Lights_R;
    public CreateLights Lights_TR;
    public CreateLights Lights_TL;
    public CreateLights Lights_BR;
    public CreateLights Lights_BL;

    private Material sky;

    [SerializeField] private OVRPassthroughLayer passthroughLayer;
    public Camera CenterEyeCam;

    // Start is called before the first frame update
    void Start()
    {
        sky = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        // 右コントローラー //////////////////////////////////////////
        if (OVRInput.GetDown(OVRInput.RawButton.A))  // simulator: B
        {
            Debug.Log("Aボタンを押した");
            StartCoroutine(Vibrate(duration: 0.5f, controller: OVRInput.Controller.RTouch));
            // 説明書き非表示
            image.SetActive(false);
            // 動画再生
            video.PlayVideo();
        }        
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Debug.Log("Bボタンを押した");
            // Debug.Log(OVRManager.instance.isInsightPassthroughEnabled);
            // Debug.Log(passthroughLayer.textureOpacity);  // [BB]Background Passthrough > OVR Passthrough Layer > Style > Opacity
            // パススルーの切り替え
            OVRManager.instance.isInsightPassthroughEnabled = !OVRManager.instance.isInsightPassthroughEnabled;
            if (OVRManager.instance.isInsightPassthroughEnabled) {
                // RenderSettings.skybox = null;
                CenterEyeCam.clearFlags = CameraClearFlags.Color;
            } else {
                // RenderSettings.skybox = sky;
                CenterEyeCam.clearFlags = CameraClearFlags.Skybox;
            }
        }

        // 左コントローラー //////////////////////////////////////////
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("Xボタンを押した");
            // 右コントローラーを0.5秒間振動させる
            StartCoroutine(Vibrate(duration: 0.5f, controller: OVRInput.Controller.RTouch));
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            Debug.Log("Yボタンを押した");
            StartCoroutine(Vibrate(duration: 0.25f, controller: OVRInput.Controller.RTouch));
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
            Lights_TR.run();
            Lights_TL.run();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
        {
            Debug.Log("右アナログスティックを下に倒した");
            Lights_BR.run();
            Lights_BL.run();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            Debug.Log("右アナログスティックを左に倒した");
            Lights_L.run();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            Debug.Log("右アナログスティックを右に倒した");
            Lights_R.run();
        }
    }


    /// <summary>
    /// Oculus Quest(やQuest2)のコントローラーを振動させるコルーチン
    /// </summary>
    public static IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active)
    {
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(duration);

        //コントローラーの振動を止める
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}


