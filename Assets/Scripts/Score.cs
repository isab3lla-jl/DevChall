using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private int score = 0;
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Meteor.OnDestroyed += () => 
        {
            score++;
            scoreText.text = $"Score: {score}";
        };
        //Meteor.OnDestroyed += OnDestroeyd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
