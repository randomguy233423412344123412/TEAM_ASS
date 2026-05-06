using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 15f;
    public Transform[] targetPoints; 

    [HideInInspector] public bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 currentTarget;

    void Awake()
    {
       
        startPosition = transform.position;
    }

    void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (targetPoints.Length == 0) return;

       
        transform.SetParent(null);
        transform.position = startPosition;

        
        int index = Random.Range(0, targetPoints.Length);
        currentTarget = targetPoints[index].position;

        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
            {
                isMoving = false;
                Debug.Log("GOAL!");
                Invoke("Shoot", 2f);
            }
        }
    }

    public void Caught()
    {
        isMoving = false;
        Debug.Log("PARATA!");
    }
}