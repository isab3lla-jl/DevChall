using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Menu, SceneDatabase.Scenes.MainMenu)
            .Unload(SceneDatabase.Slots.Credits)
            .WithOverlay()
            .WithClearUnusedAssets()
            .Perform();
    }
}
