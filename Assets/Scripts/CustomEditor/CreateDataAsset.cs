using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.IO;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

public class CreateDataAsset : EditorWindow
{
    [MenuItem("Tool/CreateAsset")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CreateDataAsset));
    }

    private void OnGUI()
    {
        if(GUILayout.Button("몬스터 데이터 생성"))
        {
            CreateMonsterAssets<MonsterData, MonsterAsset>("Monsters", FilePath.MonsterJson);
        }

        if (GUILayout.Button("아이템 데이터 생성"))
        {
            CreateMonsterAssets<ItemData, ItemAsset>("Items", FilePath.ItemJson);
        }

        if (GUILayout.Button("퀘스트 데이터 생성"))
        {
            CreateMonsterAssets<QuestData, QuestAsset>("Quests", FilePath.QuestJson);
        }
    }

    private void CreateMonsterAssets<T, U>(string createFileName, string path) where T : DataBase where U : DataAsset<T>
    {
        Managers.Data.Load<T>(path);
        var dataList = Managers.Data.GetList<T>();

        if (dataList == null || dataList.Count == 0)
        {
            Debug.LogWarning("데이터가 없습니다.");
            return;
        }

        string folderPath = $"Assets/DataAssets/{createFileName}";

        if (!AssetDatabase.IsValidFolder(folderPath))
            Directory.CreateDirectory(folderPath);

        foreach (var data in dataList)
        {
            var asset = ScriptableObject.CreateInstance<U>();

            // 데이터 복사
            asset.Data = data;

            string assetPath = Path.Combine(folderPath, $"{data.Key}.asset");

            AssetDatabase.CreateAsset(asset, assetPath);

            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup(createFileName);

            if(group == null)
            {
                group = settings.CreateGroup(createFileName, false, false, false, null, typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            }

            var guid = AssetDatabase.AssetPathToGUID(assetPath);
            var entry = settings.CreateOrMoveEntry(guid, group);
            entry.address = data.Key;
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        

        Debug.Log("Monster ScriptableObject 에셋 생성 완료");
    }
}
