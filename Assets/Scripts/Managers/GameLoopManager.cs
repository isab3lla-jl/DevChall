using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour
{
    public GameObject GameUI;

    public void RestartGame()
    {
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Session, SceneDatabase.Scenes.Session)
            .Load(SceneDatabase.Slots.SessionContent, SceneDatabase.Scenes.Game, setActive: true)
            .Unload(SceneDatabase.Slots.SessionContent)
            .Unload(SceneDatabase.Slots.Session)
            .WithOverlay()
            .WithClearUnusedAssets()
            .Perform();
    }
    public void MainMenu()
    {
        GameUI = GameObject.FindWithTag("GameUI");
        GameUI.SetActive(false);
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Menu, SceneDatabase.Scenes.MainMenu, setActive: true)
            .Unload(SceneDatabase.Slots.SessionContent)
            .Unload(SceneDatabase.Slots.Session)
            .WithOverlay()
            .WithClearUnusedAssets()
            .Perform();
    }
}
