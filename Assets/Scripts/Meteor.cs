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

    public static UnityAction OnDestroyed = () => { };
    public static UnityAction OnHit = () => { };
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
        if (other.gameObject.tag == "Bullet")
        {
            OnDestroyed();
            Destroy(gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Player")
        {
            OnHit();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Limit")
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        currentSpeed = spawner.GetComponent<Spawner>().speed;
        transform.Translate(Time.deltaTime * currentSpeed * direction);
    }
}
