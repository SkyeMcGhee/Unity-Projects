using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public bool getPickups()
    {
        return false;
    }

    void FixedUpdate()
    {
        var body = GetComponent<Rigidbody>();
        Vector2 inputValue = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var minValue = 0f;
        var maxValue = 20f;

        body.linearVelocity = inputValue.normalized * math.clamp(inputValue.magnitude, minValue, maxValue);
    }
}