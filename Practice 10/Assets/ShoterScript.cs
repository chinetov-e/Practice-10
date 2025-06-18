using UnityEngine;

public class ShoterScript : MonoBehaviour
{
    public float pullForce = 200f;
    private float maxPullTime = 6f;
    private Rigidbody rb;
    private bool isPulling = false;
    public float pullTimer = 0f;
    private GameObject springPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        springPoint = GameObject.FindWithTag("SpringPoint");
        Debug.Log(springPoint);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !isPulling)
        {
            isPulling = true;
            pullTimer = maxPullTime;
        }
    }

    void Update()
    {
        if (isPulling)
        {
            Vector3 plungerDirection = (springPoint.transform.position - rb.transform.position);

            rb.AddForce(plungerDirection * pullForce, ForceMode.Force);
            pullTimer -= Time.deltaTime;

            if (pullTimer <= 0)
            {
                isPulling = false;
                rb.AddForce(-plungerDirection * 250f, ForceMode.Impulse);
            }
        }

    }

}
