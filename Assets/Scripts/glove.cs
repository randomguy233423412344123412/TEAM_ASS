using UnityEngine;

public class VRHand : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ball"))
        {
            BallController ball = other.GetComponent<BallController>();

            if (ball != null && ball.isMoving)
            {
                ball.Caught(); 

                
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, 0, 0.1f); 

                Debug.Log("Parata VR effettuata con: " + gameObject.name);

               
                Invoke("ResetMatch", 2f);
            }
        }
    }

    void ResetMatch()
    {
        BallController ball = FindObjectOfType<BallController>();
        if (ball != null) ball.Shoot();
    }
}