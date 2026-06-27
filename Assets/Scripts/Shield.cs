using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    [Header("Movement")]
    public Vector3 direction;
    public float currentSpeed = 2f;
    [Header("Spawn Point")]
    public GameObject spawner;

    public static UnityAction OnTakenShield = () => { };

    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
    }

    void OnEnable()
    {
        direction = Vector3.down;
        direction.x = Random.Range(-0.1f, 0.1f);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Limit")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnTakenShield();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        currentSpeed = spawner.GetComponent<Spawner>().speed;
        transform.Translate(Time.deltaTime * currentSpeed * direction);
    }
}
