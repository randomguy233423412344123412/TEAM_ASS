using UnityEngine;

public class TiroPalla : MonoBehaviour
{
    public Transform[] puntiPorta; // punti dentro la porta
    public float forzaTiro = 10f;

    private Rigidbody rb;
    private bool tirata = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Tocca schermo (o click mouse su PC)
        if (Input.GetMouseButtonDown(0) && !tirata)
        {
            Tira();
        }
    }

    void Tira()
    {
        tirata = true;

        // scegli punto casuale
        int index = Random.Range(0, puntiPorta.Length);
        Transform target = puntiPorta[index];

        // direzione verso il punto
        Vector3 direzione = (target.position - transform.position).normalized;

        // applica forza
        rb.AddForce(direzione * forzaTiro, ForceMode.Impulse);

        Debug.Log("Tiro verso: " + target.name);
    }
}
