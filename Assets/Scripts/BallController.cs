using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 15f;
    public Transform[] targetPoints; // I tuoi 5 punti

    [HideInInspector] public bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 currentTarget;

    void Awake()
    {
        // Memorizza dove si trova la palla all'inizio (dischetto)
        startPosition = transform.position;
    }

    void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (targetPoints.Length == 0) return;

        // Torna al dischetto e si stacca dal guantone
        transform.SetParent(null);
        transform.position = startPosition;

        // Sceglie un punto a caso tra i 5
        int index = Random.Range(0, targetPoints.Length);
        currentTarget = targetPoints[index].position;

        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

            // Se arriva a destinazione (GOAL)
            if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
            {
                isMoving = false;
                Debug.Log("GOAL!");
                Invoke("Shoot", 2f); // Riprova dopo 2 secondi
            }
        }
    }

    public void Caught()
    {
        isMoving = false;
        Debug.Log("PARATA!");
    }
}