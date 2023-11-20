using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLights : MonoBehaviour
{
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    [SerializeField] private int rightNum;  // ライトの個数
    [SerializeField] private float oneStrokeDuration = 0.6f;  // ライトの1ストロークにかける時間
    [SerializeField] private float d_i = 0.125f;
    [SerializeField] private float i_m = 50;
    [SerializeField] private int strokeNum = 5;
    // [SerializeField] private bool shouldLog = false;

    public GameObject lightObjectPrefab;
    private List<GameObject> lightObjects = new List<GameObject>();
    private bool isRunning = false;
    // private OutputCSV csv;

    private void Start()
    {
        // SpawnLights();
        
        // StartCoroutine(ExecuteProcessA());
    }

    private void SpawnLights()
    {
        for (int i = 0; i <= rightNum; i++)
        {
            float t = (float)i / rightNum;
            Vector3 position = Vector3.Lerp(startPoint, endPoint, t);
            GameObject lightObject = Instantiate(lightObjectPrefab, position, Quaternion.identity);
            lightObjects.Add(lightObject);
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
                StartCoroutine(ChangeIntensity(lightObjects[i].GetComponentInChildren<Light>(), d_i, i_m));
                yield return new WaitForSeconds(delay);
            }
        }
        isRunning = false;
    }

    private IEnumerator ChangeIntensity(Light light, float duration, float targetIntensity)
    {
        float initialIntensity = light.intensity;
        float elapsedTime = 0;

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