using UnityEngine;

public class BirdLooper : MonoBehaviour
{
    public float speed = 2f;
    public float minY = 2f;
    public float maxY = 5f;
    public float leftX = -10f;
    public float rightX = 10f;

    private void Update()
    {
        
        transform.position += Vector3.right * speed * Time.deltaTime;

        
        if (transform.position.x > rightX)
        {
            float newY = Random.Range(minY, maxY);
            transform.position = new Vector3(leftX, newY, transform.position.z);
        }
    }
}
