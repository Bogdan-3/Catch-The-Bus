using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    InputAction MoveAction;
    InputAction JumpAction;
    InputAction RotateAction;

    Rigidbody rb;

    public float JumpPower;
    public float MovingSpeed;
    public float RotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;

        MoveAction=InputSystem.actions.FindAction("Move");
        JumpAction=InputSystem.actions.FindAction("Jump");
        RotateAction=InputSystem.actions.FindAction("Look");

        rb=GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 MoveValue=new Vector3(MoveAction.ReadValue<Vector2>().x,0,MoveAction.ReadValue<Vector2>().y);
        Vector3.Normalize(MoveValue);
        this.transform.Translate(MoveValue*Time.deltaTime*MovingSpeed);
    }

    void Jump()
    {
        if(JumpAction.IsPressed() && Physics.Raycast(transform.position,Vector3.down,1.25f))
        {
            rb.AddForce(Vector3.up*JumpPower);
        }
    }

    void Rotate()
    {
        Vector3 RotateValue=new Vector3(0,RotateAction.ReadValue<Vector2>().x,0);
        this.transform.Rotate(RotateValue*Time.deltaTime*RotateSpeed);
    }
}
