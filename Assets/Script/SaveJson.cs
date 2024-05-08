using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveJson
{
#if UNITY_EDITOR

    private readonly static string SAVEDATA_PATH = "Assets/" + "Save/SaveData" + ".json";

#endif
    public static void Save<T>(T data)
        where T : class
    {
        var json = JsonUtility.ToJson(data);
        if (!File.Exists(SAVEDATA_PATH))
        {
            File.Create(SAVEDATA_PATH);
        }
        File.WriteAllText(SAVEDATA_PATH, json);
    }
    public static T Load<T>()
        where T: class
    {
        if (!File.Exists(SAVEDATA_PATH)) return null;
        var json = File.ReadAllText(SAVEDATA_PATH);
        return JsonUtility.FromJson<T>(json);
    }
}
