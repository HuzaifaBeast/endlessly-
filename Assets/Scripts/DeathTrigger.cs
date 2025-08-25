using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RunnerMovement runner = other.GetComponent<RunnerMovement>();
            if (runner != null)
            {
                runner.Die();
            }
        }
    }
}
