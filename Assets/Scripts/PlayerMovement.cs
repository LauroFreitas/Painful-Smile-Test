using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float maxVerticalSpeed;
    public float maxRotationSpeed;
    public float Speed;


    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * maxVerticalSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(0, 0, -1 * Input.GetAxis("Horizontal") * maxRotationSpeed * Time.deltaTime));
    }
}
