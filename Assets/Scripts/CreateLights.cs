using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class CreateLights : MonoBehaviour
{
    public GameObject lightObjectPrefab;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 spacing;
    [SerializeField] private int rightNum = 5;  // ライトの個数
    [SerializeField] private float oneStrokeDuration = 0.6f;  // ライトの1ストロークにかける時間
    [SerializeField] private float d_i = 0.125f;
    [SerializeField] private float targetIntensity = 2;//50;
    [SerializeField] private int strokeNum = 5;
    [SerializeField] private Color lightColor;
    // [SerializeField] private bool shouldLog = false;

    private List<GameObject> lightObjects = new List<GameObject>();
    private bool isRunning = false;
    // private OutputCSV csv;

    private void Start()
    {
        CreateLight();
    }

    private void CreateLight() {
        for (int i = 0; i <= rightNum; i++)
        {
            GameObject newLight = Instantiate(lightObjectPrefab, new Vector3(startPoint[0] + spacing[0] * i, startPoint[1] + spacing[1] * i, startPoint[2] ), Quaternion.identity);
            // 新しいライトをこのオブジェクトの子として設定(false:インスタンスのローカルtransformを維持)
            newLight.transform.SetParent(transform, false);
            Light lightComponent = newLight.GetComponent<Light>();
            if (lightComponent != null)
            {
                lightComponent.color = lightColor;  // ライトの色を設定
            }
            lightObjects.Add(newLight);
        }
    }


    // 実行メソッド
    public void run(){
        if (!isRunning) StartCoroutine(ExecuteProcessA());
    }

    private IEnumerator ExecuteProcessA()
    {
        isRunning = true;
        for (int c = 0; c < strokeNum; c++)
        {
            float delay = (float)oneStrokeDuration / (rightNum + 1);
            for (int i = 0; i <= rightNum; i++)
            {
                StartCoroutine(ChangeIntensity(lightObjects[i].GetComponentInChildren<Light>(), d_i, this.targetIntensity));
                yield return new WaitForSeconds(delay);
            }
        }
        isRunning = false;
        Debug.Log("Finished");
    }

    private IEnumerator ChangeIntensity(Light light, float duration, float targetIntensity)
    {
        float initialIntensity = light.intensity;
        float elapsedTime = 0;
        Debug.Log("Intensity"+initialIntensity+"->"+targetIntensity);
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            light.intensity = Mathf.Lerp(initialIntensity, targetIntensity, t);
            yield return null;
        }

        elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            light.intensity = Mathf.Lerp(targetIntensity, 0, t);
            yield return null;
        }
    }
}