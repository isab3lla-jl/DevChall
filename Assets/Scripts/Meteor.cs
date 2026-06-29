using UnityEngine;
using UnityEngine.Events;

public class Meteor : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite[] meteorSprites;
    public SpriteRenderer spriteRenderer;

    [Header("Movement")]
    public Vector3 direction;
    public float currentSpeed = 2f;

    [Header("Spawn Point")]
    public GameObject spawner;

    public static event System.Action OnDestroyed;
    public static event System.Action OnHit;
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
    }
    void OnEnable()
    {
        spriteRenderer.sprite = meteorSprites[Random.Range(0, meteorSprites.Length)];
        direction = Vector3.down;
        direction.x = Random.Range(-0.5f, 0.5f);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            OnHit?.Invoke();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (spawner != null)
        {
            currentSpeed = spawner.GetComponent<Spawner>().speed;
        }
        transform.Translate(Time.deltaTime * currentSpeed * direction);
    }

    public static void ResetEvents()
    {
        OnDestroyed = null;
        OnHit = null;
    }

}
