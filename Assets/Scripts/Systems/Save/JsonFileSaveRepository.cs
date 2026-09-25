using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class JsonFileSaveRepository : ISaveRepository
{
    private readonly string filePath;
    public JsonFileSaveRepository()
    {
        filePath = Path.Combine(Application.persistentDataPath, "save.json");
    }
    public async Task SaveAsync(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        await File.WriteAllTextAsync(filePath, json);
    }
    public async Task<SaveData> LoadAsync()
    {
        if(!File.Exists(filePath))
            return new SaveData();

        string json = await File.ReadAllTextAsync(filePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return data ?? new SaveData();
    }
}
