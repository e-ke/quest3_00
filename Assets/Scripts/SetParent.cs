using UnityEngine;

public class SetParent : MonoBehaviour
{
    // SerializeFieldを使用してインスペクターから親オブジェクトを設定できるようにする
    [SerializeField] private GameObject parentObject;

    void Start()
    {
        // 親オブジェクトが設定されているか確認
        if (parentObject != null)
        {
            // このスクリプトがアタッチされているオブジェクトを、指定した親オブジェクトの子にする
            transform.SetParent(parentObject.transform);
        }
        else
        {
            Debug.Log("Parent object is not set for " + gameObject.name);
        }
    }
}