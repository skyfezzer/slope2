using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerUI ui;
    public new Rigidbody rigidbody;
    private InputAction rightAction;
    private InputAction leftAction;
    [SerializeField]
    public float turningForce = 25f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rightAction = new InputAction("Right", InputActionType.Button, "<Keyboard>/rightArrow");
        leftAction = new InputAction("Left", InputActionType.Button, "<Keyboard>/leftArrow");
        rightAction.Enable();
        leftAction.Enable();
        ui = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        AddForwardForce();

        AddSideForce();
    }

    void AddForwardForce()
    {
        rigidbody.AddForce((Vector3.forward * Time.fixedDeltaTime).normalized, ForceMode.Force);
    }

    void AddSideForce()
    {
        float horizontalInput = rightAction.ReadValue<float>() - leftAction.ReadValue<float>();
        if(horizontalInput != 0){
            Vector3 movement = (Vector3.right * horizontalInput).normalized;
            movement = movement * turningForce;
            Debug.Log(horizontalInput +" = "+ movement);
            rigidbody.AddForce(movement, ForceMode.VelocityChange);
        }
    }

    public void BoostUp(){
        Vector3 movement = new Vector3(0f,1f,12f);
        rigidbody.AddForce(movement, ForceMode.VelocityChange);
        ui.ShowBoost();
    }
}
