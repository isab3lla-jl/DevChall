using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float speedIncreaseRate = 0.1f;
    public float lifespan = 2f;

    void Update()
    {
        speed += speedIncreaseRate * Time.deltaTime;
        transform.Translate(Time.deltaTime * speed * Vector3.up);
        lifespan -= Time.deltaTime;
        if(lifespan <= 0f)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void Reset(Vector3 position)
    {
        lifespan = 2f;
        transform.position = position;
    }
}
