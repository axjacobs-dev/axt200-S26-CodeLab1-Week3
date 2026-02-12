using UnityEngine;
using UnityEngine.InputSystem;
    
public class WASDController : MonoBehaviour
{ 
    Rigidbody rb; //rigidbody for the GameObject that this script is attached to
    
    public float moveForce = 10f; //the force we add to a GameObject to make it move

    public float moveSpeed = 10f;
    //public Key keyUp = Key.W; //the key we press to make GameObject go up for use with new input system

    //public Key keyDown = Key.S; //the key we press to make GameObject go down for use in new input system
    
    public Key keyLeft = Key.A;
    
    public Key keyRight = Key.D;
    
    public Key keyUp = Key.W;
    
    public Key keyForward = Key.S;

    Keyboard keyboard = Keyboard.current;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (keyboard[keyLeft].isPressed)
        {
            //rb.AddForce(Vector3.left * moveForce, ForceMode.Acceleration); //give GameObject a leftward force
            transform.position += Vector3.left * Time.deltaTime;
            Debug.Log ("going left!");
        }

        if (keyboard[keyRight].isPressed)
        {
            //rb.AddForce(Vector3.right * moveForce, ForceMode.Acceleration); //give GameObject a rightward force
            //rb.linearVelocity = transform.right * moveSpeed;
            transform.position += Vector3.right * Time.deltaTime;
            Debug.Log ("going right!");
        }

        if (keyboard[keyUp].isPressed)
        {
            rb.AddForce(Vector3.up * moveForce, ForceMode.Impulse); //GameObject moves forwards
            Debug.Log ("going up!");
        }

        if (keyboard[keyForward].isPressed)
        {
            //rb.AddForce(Vector3.back * moveForce, ForceMode.Acceleration); //GameObject moves backwards
            transform.position += Vector3.forward * Time.deltaTime;
            Debug.Log ("going back!");
        }

        // if(Input.GetKey(KeyCode.S))
        // {
        //     rb.AddForce(Vector3.down * moveForce, ForceMode.Acceleration); // give the GameObject a downward force
        // }
    }
}