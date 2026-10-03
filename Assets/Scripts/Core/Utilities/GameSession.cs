public static class GameSession
{
    public static StageData SelectedStage {get; private set;}    
    public static void SelectStage(StageData stage)
    {
        SelectedStage = stage;
    }
    
}
