using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJson
{
    // �Z�[�u�f�[�^�̕ۑ���p�X�i�G�f�B�^�ł̂ݎg�p�j
#if UNITY_EDITOR
    private readonly static string SAVEDATA_PATH = "Assets/" + "Save/SaveData" + ".json";
#endif

    // �f�[�^��JSON�`���ŕۑ����郁�\�b�h
    public static void Save<T>(T data)
        where T : class
    {
        var json = JsonUtility.ToJson(data);
        // �ۑ���t�@�C�������݂��Ȃ��ꍇ�͐V�K�쐬
        if (!File.Exists(SAVEDATA_PATH))
        {
            File.Create(SAVEDATA_PATH);
        }
        // �f�[�^��JSON�`���Ńt�@�C���ɏ�������
        File.WriteAllText(SAVEDATA_PATH, json);
    }

    // JSON�`���̃f�[�^��ǂݍ��ރ��\�b�h
    public static T Load<T>()
        where T : class
    {
        // �t�@�C�������݂��Ȃ��ꍇ��null��Ԃ�
        if (!File.Exists(SAVEDATA_PATH)) return null;
        // �t�@�C������JSON�`���̃f�[�^��ǂݍ��݁AT�^�ɕϊ����ĕԂ�
        var json = File.ReadAllText(SAVEDATA_PATH);
        return JsonUtility.FromJson<T>(json);
    }
}
