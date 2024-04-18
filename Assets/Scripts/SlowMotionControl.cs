using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;


public class SlowMotionControl : MonoBehaviour
{
    public InputActionReference leftVelocity = null;
    public InputActionReference rightVelocity = null;
    public InputActionReference headVelocity = null;
    float leftSpeed, rightSpeed, headSpeed, combinedSpeed;

    public float sensitivity = 0.03f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(rightVelocity!=null) rightSpeed = rightVelocity.action.ReadValue<UnityEngine.Vector3>().magnitude;
        if (leftVelocity != null)  leftSpeed = leftVelocity.action.ReadValue<UnityEngine.Vector3>().magnitude;
        if (headVelocity != null) headSpeed = headVelocity.action.ReadValue<UnityEngine.Vector3>().magnitude;

        combinedSpeed = rightSpeed + leftSpeed + headSpeed;

        if(combinedSpeed >= 0.8 &&  combinedSpeed <= 1)
        {
            Time.timeScale = combinedSpeed - .4f;
            Time.fixedDeltaTime = Time.timeScale * sensitivity;
        }

       else if (combinedSpeed > 1)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * sensitivity;
        }

    }
}