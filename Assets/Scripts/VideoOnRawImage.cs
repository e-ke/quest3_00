using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoOnRawImage : MonoBehaviour
{
    public RawImage rawImage; // UIのRawImageにアタッチするための参照
    private VideoPlayer videoPlayer;
    private bool isVideoPrepared = false; // 動画が準備完了したかのフラグ


    void Start()
    {
        // RawImageとVideoPlayerのセットアップ
        if (!rawImage) rawImage = GetComponent<RawImage>();
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        // 動画パスの取得と動画の再生を開始する
        StartCoroutine(PrepareVideo());
    }

    // 動画を再生する
    public void PlayVideo()
    {
        if (isVideoPrepared && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

    private IEnumerator PrepareVideo()
    {
        string moviePath = "";
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "1.mp4");

        if (filePath.Contains("://"))
        {
            // Androidの場合の処理
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            yield return www.SendWebRequest();

            moviePath = www.url;
        }
        else
        {
            // それ以外のプラットフォーム
            moviePath = filePath;
        }

        // 動画プレイヤーの設定と再生
        videoPlayer.url = moviePath;
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // RawImageのサイズを動画のサイズに合わせる
        // UpdateRawImageSize(videoPlayer.texture.width, videoPlayer.texture.height);

        rawImage.texture = videoPlayer.texture;
        isVideoPrepared = true; // 動画が準備完了
    }

    private void UpdateRawImageSize(int width, int height)
    {
        rawImage.rectTransform.sizeDelta = new Vector2(width, height);
    }
}
