using System.IO;
using UnityEngine;

public class OutputText : MonoBehaviour
{
    void Start()
    {
        string filePath = "/storage/emulated/0/Movies/data.csv";
        CreateOrAppendCsvFile(filePath, "test");
        writeTest();
    }

    private void CreateOrAppendCsvFile(string filePath, string content)
    {
        // StreamWriterを使ってファイルに書き込む
        // 第二引数がtrueの場合はファイルの末尾に追記し、falseの場合はファイルを新規作成する（既存の内容を上書き）
        using (StreamWriter writer = new StreamWriter(filePath, true, System.Text.Encoding.UTF8))
        {
            writer.Write(content);
        }

        Debug.Log("CSV file created or updated: " + filePath);
    }

    private void writeTest() {
        string filePath = Application.persistentDataPath + "/test.txt";

        using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
        {
            writer.WriteLine("Hello.File.");
            writer.WriteLine("line2");
        }

        using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8))
        {
            string readText = reader.ReadToEnd();
            reader.Close();
            // 読み込んだテキストを利用する関数(readText);
        }
    }
}
