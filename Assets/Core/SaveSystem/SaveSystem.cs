using System.IO;
using Core.DummyScripts;
using UnityEngine;

namespace Core.SaveSystem
{
    public static class SaveSystem
    {
        private static readonly string SAVE_FILE_NAME = "player_progress.json";

        public static void Save(UnitData data)
        {
            var json = JsonUtility.ToJson(data, true);
            var path = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
            
            try
            {
                File.WriteAllText(path, json);
                Debug.Log($"Saving is successful: {path}");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Saving error: {e.Message}");
            }
        }

        public static UnitData Load()
        {
            var path = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
            
            if (File.Exists(path))
            {
                try
                {
                    var json = File.ReadAllText(path);
                    var data = JsonUtility.FromJson<UnitData>(json);
                    Debug.Log($"Saving is successful: {path}");
                    return data;
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Saving error: {e.Message}. Creating a new save.");
                    return new UnitData();
                }
            }
            else
            {
                Debug.Log("The save file was not found. Creating a new one.");
                return new UnitData();
            }
        }
    }
}