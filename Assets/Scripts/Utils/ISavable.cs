namespace Utils
{
    public interface ISavable
    {
        void PopulateSaveData(SaveData a_SaveData);
        void LoadFromSaveData(SaveData a_SaveData);
    }
}