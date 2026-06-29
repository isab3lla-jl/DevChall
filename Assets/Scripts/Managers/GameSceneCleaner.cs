using UnityEngine;

public class GameSceneCleaner : MonoBehaviour
{
    void Awake()
    {
        ClearAllStaticEvents();
    }

    public static void ClearAllStaticEvents()
    {
        PlayerShip.ResetEvents();
        Meteor.ResetEvents();
        Lives.ResetEvents();
        Shield.ResetEvents();
        Debug.Log("Static events cleared.");
    }
}
