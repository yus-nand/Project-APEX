using System;
using System.Collections.Generic;
[Serializable]
public class SaveData
{
    public int schemaVersion = 1;
    public StatisticsData statistics = new();

    public int coins;
    public List<PermanentUpgradeSaveEntry> permanentUpgrades = new();
    public List<string> unlocks = new();
    public SettingsData settings = new();
}
