using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Renderer bgRenderer;

    void Start()
    {
        PlayerShip.OnGameOver += HandleGameOver;
    }

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, speed*Time.deltaTime);
    }

    private void HandleGameOver()
    {
        speed = 0f;
    }
}
