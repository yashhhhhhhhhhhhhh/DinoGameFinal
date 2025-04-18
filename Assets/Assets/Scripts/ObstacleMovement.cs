using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public GameObject[] obstacle1;
    public float obstacleSpeed = 2f;
    public Transform target;
    private Vector3 spawnPoint;
    public GameObject spawn;

    void Start()
    {
        spawnPoint = spawn.transform.position;
    }

    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            moveObstacles();
        }
    }

    void moveObstacles()
    {
        for (int i = 0; i < obstacle1.Length; i++)
        {
            Vector3 targetPos = new Vector3(target.position.x, obstacle1[i].transform.position.y, obstacle1[i].transform.position.z);

            obstacle1[i].transform.position = Vector3.MoveTowards(
                obstacle1[i].transform.position,
                targetPos,
                Time.deltaTime * obstacleSpeed
            );

            if (Vector3.Distance(obstacle1[i].transform.position, targetPos) < 0.1f)
            {
                obstacle1[i].transform.position = GetRandomOffset();
            }
        }
    }

    Vector3 GetRandomOffset()
    {
        float randomXOffset = Random.Range(20f, 25f); 
        float newX = target.position.x + randomXOffset;
        return new Vector3(newX, spawnPoint.y, spawnPoint.z);
    }
}
