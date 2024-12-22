using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool pickup;
    public Rigidbody rb;
    public bool getPickups()
    {
        return pickup;
    }

    public void Start()
    {

        pickup = false;
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        /* var body = GetComponent<Rigidbody>();
         Vector2 inputValue = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
         var minValue = 0f;
         var maxValue = 20f;

         body.linearVelocity = inputValue.normalized * math.clamp(inputValue.magnitude, minValue, maxValue);*/

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

        if(IsGrounded() == true && Input.GetKeyDown("space"))
        {

            float Jump = Input.GetAxis("Jump");
            Vector3 movementUp = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }
        if(pickup && Input.GetKeyDown("g"))
        {

        }
    }

    public bool IsGrounded()
    {
        if (rb.linearVelocity.y == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            pickup = true;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Grate" && pickup && Input.GetKeyDown(KeyCode.G))
        {
            other.gameObject.SetActive(false);
        }
    }
}