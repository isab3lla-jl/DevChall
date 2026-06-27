using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    [Header("Movement")]
    public Camera cam;
    Vector2 mousePos;
    public float speed = 15f;
    Vector3 targetPos;
    private Rigidbody2D rb;
    private bool canMove = true;

    [Header("Bullets")]
    public Bullet bulletPrefab;
    public Transform firePoint;
    public float fireRate = 3f;
    private float timer = 0f;
    public int poolSize = 20;
    public List<Bullet> bulletsPool;

    [Header("Shield")]
    public GameObject shieldPrefab;
    
    [Header("Lives")]
    public int lives = 3;
    public TMP_Text livesText;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    public static UnityAction OnGameOver = () => { };

    void Start()
    {
        // Movement SetUp
        rb = GetComponent<Rigidbody2D>();
        targetPos = transform.position;
        // Bullet pool
        bulletsPool = new List<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            var b = Instantiate<Bullet>(bulletPrefab, firePoint.position, Quaternion.identity);
            Scene gameScene = SceneManager.GetSceneByName("Game");
            if (gameScene.isLoaded)
            {
                SceneManager.MoveGameObjectToScene(b.gameObject, gameScene);
            }
            bulletsPool.Add(b);
            b.gameObject.SetActive(false);
        }

        // - Lives text & game over logic
        Meteor.OnHit += () => 
        {
            lives--;
            livesText.text = $"Lives: {lives}";
            if (lives <= 0)
            {
                //Debug.Log("Game Over!");
                OnGameOver();
                gameOverPanel.SetActive(true);
                Debug.Log("Game Over!");
                StopMovement();
                canMove = false;
            }
        };

        // + Lives text
        Lives.OnTakenLife += () =>
        {
            lives++;
            livesText.text = $"Lives: {lives}";
        };
        
        // Shield instantiate
        Shield.OnTakenShield += () =>
        {
            Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);
        };
    }

    void Update()
    {
        // Movement
        if (!canMove) return;
        if (Input.GetMouseButton(0))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            targetPos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }

        // Shooting
        timer += Time.deltaTime;
        if(timer >= 1f/fireRate)
        {
            timer = 0f;
            var bullet = bulletsPool.Find(b => !b.isActiveAndEnabled);
            if (bullet == null) return;
            bullet.gameObject.SetActive(true);
            bullet.Reset(firePoint.position);
        }
    }

    void FixedUpdate()
    {
        // Movement
        if (!canMove) return;
        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector3 nextPos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(nextPos);

    }

    // Stop/constrict movement logic
    private void StopMovement()
    {
        rb.linearVelocity = Vector2.zero;
        targetPos = rb.position;
    }

     void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLimit"))
        {
            Debug.Log("Player is touching the limit");
            targetPos = transform.position;
            rb.linearVelocity = Vector2.zero;
        }
    }
}
