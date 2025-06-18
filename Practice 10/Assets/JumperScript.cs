using UnityEngine;

public class JumperScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Rigidbody ball = other.rigidbody;

        Vector3 direction = (ball.transform.position - transform.position).normalized;

        ball.AddForce(direction * 40f, ForceMode.Impulse);
    }
}
