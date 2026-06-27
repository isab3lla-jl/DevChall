using UnityEngine;

public class CoreManager : MonoBehaviour
{
    //Core steup
    // Load everything like audiomanager savesystem etc
    void Start()
    {
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Menu, SceneDatabase.Scenes.MainMenu, setActive: true)
            .WithOverlay()
            .Perform();
    }
}
