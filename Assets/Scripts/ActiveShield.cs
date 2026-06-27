using UnityEngine;

public class ActiveShield : MonoBehaviour
{
    public float lifetime = 3f;

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
