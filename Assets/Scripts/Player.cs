using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;


    private bool isWalking;


    private void Update()
    {
        Vector2 inputVector = new Vector2();

        if (Keyboard.current.wKey.isPressed){
            inputVector.y = +1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputVector.y = -1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            inputVector.x = +1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            inputVector.x = -1;
        }
        inputVector=inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x,0,inputVector.y);
        transform.position += moveDir * Time.deltaTime * speed;

        float rotationSpeed = 10f;
        transform.forward=Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotationSpeed);


        isWalking = moveDir != Vector3.zero;
    }
public bool IsWalking()
    {
        return isWalking;
    }
}
