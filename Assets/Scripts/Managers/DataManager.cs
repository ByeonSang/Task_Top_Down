using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager
{
    private const string MonsterJson = "Json/MonsterJson";
    private const string ItemJson = "Json/ItemJson";
    private const string QuestJson = "Json/QuestJson";

    private Dictionary<string, List<DataBase>> _datas = new();

    public void Load()
    {
        JsonDeserialize<MonsterData>(MonsterJson);
        JsonDeserialize<ItemData>(ItemJson);
        JsonDeserialize<QuestData>(QuestJson);
    }

    private void JsonDeserialize<T>(string path) where T : DataBase
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);

        if(textAsset != null)
        {
            T[] dataClassList = JsonConvert.DeserializeObject<T[]>(textAsset.text);

            if (!_datas.TryGetValue(typeof(T).Name, out var list))
                _datas.Add(typeof(T).Name, list = new());
            else
                list.Clear();

                foreach (var dataClass in dataClassList)
                {
                    list.Add(dataClass);
                }
        }
        else
        {
            Utils.LogError("파일을 읽어 올 수 없습니다.");
        }
    }

/*    public T GetData<T>(string key) where T : DataBase
    {
        DataBase data = null;
        if (_datas.TryGetValue(key, out data))
            return data as T;
        else if(_keys.TryGetValue(key, out var keyInfo))
        {
            if (_datas.TryGetValue(keyInfo, out data))
                return data as T;
            else
                Utils.LogWarning("현재 키로된 데이터가 없습니다.");
        }

        return null;
    }*/

    public List<T> GetList<T>() where T : DataBase
    {
        if (!_datas.TryGetValue(typeof(T).Name, out var list))
            return null;

        return list.OfType<T>().ToList();
    }
}
