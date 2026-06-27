using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public GameObject GameUI;
    public void RestartGame()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
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
