using UnityEngine;
using System.Collections.Generic; // Listを使用するために必要

public class MirroredChilds : MonoBehaviour
{
    [SerializeField] private bool mirrorX; // X軸に対して対称にするか
    [SerializeField] private bool mirrorY; // Y軸に対して対称にするか
    [SerializeField] private bool mirrorZ; // Z軸に対して対称にするか

    void Start()
    {
        // すべての子オブジェクトを一時的なリストに保存
        List<Transform> originalChildren = new List<Transform>();
        foreach (Transform child in transform)
        {
            originalChildren.Add(child);
        }

        // 保存されたリストを使用して複製を行う
        foreach (Transform child in originalChildren)
        {
            // 対称な位置を計算
            Vector3 mirroredPosition = new Vector3(
                mirrorX ? -child.localPosition.x : child.localPosition.x,
                mirrorY ? -child.localPosition.y : child.localPosition.y,
                mirrorZ ? -child.localPosition.z : child.localPosition.z);
            
            // 子オブジェクトを複製し、計算した位置に配置
            Transform mirroredChild = Instantiate(child, mirroredPosition, Quaternion.identity);
            mirroredChild.SetParent(transform, false);
            // 名前を変更して対称オブジェクトであることを明示（オプション）
            mirroredChild.name = child.name + "_mirrored";
        }
    }
}
