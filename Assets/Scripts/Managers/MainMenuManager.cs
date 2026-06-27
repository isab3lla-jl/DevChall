using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public void StartGame()
    {
        tutorialPanel.SetActive(true);
    }
    public void Credits()
    {
        
    }
    public void QuitGame()
    {
        //Application.Quit();
    }
    public void Tutorial()
    {
        
    }
    public void PlayGame()
    {
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Session, SceneDatabase.Scenes.Session)
            .Load(SceneDatabase.Slots.SessionContent, SceneDatabase.Scenes.Game, setActive: true)
            .Unload(SceneDatabase.Slots.Menu)
            .WithOverlay()
            .WithClearUnusedAssets()
            .Perform();
    }
}
