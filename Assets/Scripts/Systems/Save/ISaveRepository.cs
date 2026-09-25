using System.Threading.Tasks;
public interface ISaveRepository
{
    Task SaveAsync(SaveData data);
    Task<SaveData> LoadAsync();
}
