using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJson
{
    // セーブデータの保存先パス（エディタでのみ使用）
#if UNITY_EDITOR
    private readonly static string SAVEDATA_PATH = "Assets/" + "Save/SaveData" + ".json";
#endif

    // データをJSON形式で保存するメソッド
    public static void Save<T>(T data)
        where T : class
    {
        var json = JsonUtility.ToJson(data);
        // 保存先ファイルが存在しない場合は新規作成
        if (!File.Exists(SAVEDATA_PATH))
        {
            File.Create(SAVEDATA_PATH);
        }
        // データをJSON形式でファイルに書き込む
        File.WriteAllText(SAVEDATA_PATH, json);
    }

    // JSON形式のデータを読み込むメソッド
    public static T Load<T>()
        where T : class
    {
        // ファイルが存在しない場合はnullを返す
        if (!File.Exists(SAVEDATA_PATH)) return null;
        // ファイルからJSON形式のデータを読み込み、T型に変換して返す
        var json = File.ReadAllText(SAVEDATA_PATH);
        return JsonUtility.FromJson<T>(json);
    }
}
