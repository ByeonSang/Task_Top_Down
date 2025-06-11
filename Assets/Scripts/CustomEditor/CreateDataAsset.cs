using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.IO;

public class CreateDataAsset : EditorWindow
{
    [MenuItem("Tool/CreateAsset")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CreateDataAsset));
    }

    private void OnGUI()
    {
        if(GUILayout.Button("데이터 에셋 생성"))
        {
            CreateMonsterAssets();
        }
    }

    private void CreateMonsterAssets()
    {
        Managers.Data.Load();
        var monsterList = Managers.Data.GetList<MonsterData>();

        if (monsterList == null || monsterList.Count == 0)
        {
            Debug.LogWarning("Monster 데이터가 없습니다.");
            return;
        }

        string folderPath = "Assets/DataAssets/Monsters";

        if (!AssetDatabase.IsValidFolder(folderPath))
            Directory.CreateDirectory(folderPath);

        foreach (var data in monsterList)
        {
            var asset = ScriptableObject.CreateInstance<MonsterAsset>();

            // 데이터 복사
            asset.Data = data;

            string assetPath = Path.Combine(folderPath, $"{data.Key}.asset");

            AssetDatabase.CreateAsset(asset, assetPath);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Monster ScriptableObject 에셋 생성 완료");
    }
}
