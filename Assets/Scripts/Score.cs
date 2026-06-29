using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private int score = 0;
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Meteor.OnDestroyed += HandleMeteorDestroyed;
        //Meteor.OnDestroyed += OnDestroeyd;
    }

    private void HandleMeteorDestroyed()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}
