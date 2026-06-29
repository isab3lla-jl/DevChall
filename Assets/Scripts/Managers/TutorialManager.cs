using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Menu, SceneDatabase.Scenes.MainMenu, setActive: true)
            .Unload(SceneDatabase.Slots.Tutorial)
            .WithOverlay()
            .WithClearUnusedAssets()
            .Perform();
    }
    public void PlayGame()
    {
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Session, SceneDatabase.Scenes.Session)
            .Load(SceneDatabase.Slots.SessionContent, SceneDatabase.Scenes.Game, setActive: true)
            .Unload(SceneDatabase.Slots.Tutorial)
            .WithOverlay()
            .WithClearUnusedAssets()
            .Perform();
    }
}
