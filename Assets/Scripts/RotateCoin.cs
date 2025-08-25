using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 180f, 0); // Y-axis rotation

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
