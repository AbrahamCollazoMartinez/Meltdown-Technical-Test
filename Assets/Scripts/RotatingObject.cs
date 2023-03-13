using UnityEngine;
using UnityEngine.Events;

public class RotatingObject : MonoBehaviour
{
    // Variables for controlling rotation speed
    public float normalSpeed = 10f;
    public float fastSpeed = 20f;
    public float fastDuration = 2f;

    // Variables for tracking rotation state
    private float currentSpeed;
    private bool isRotating = false;
    private float rotationStartTime;

    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial rotation speed
        currentSpeed = normalSpeed;

        // Store the initial rotation of the object
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object is currently rotating
        if (isRotating)
        {
            // Calculate the rotation angle based on the elapsed time and current speed
            float elapsed = Time.time - rotationStartTime;
            float angle = elapsed * currentSpeed;

            // Rotate the object by the calculated angle around the Y-axis
            transform.rotation = Quaternion.Euler(0, angle, -90);

            // Check if the object has completed a full rotation
            if (angle >= 360f)
            {
                // Reset the rotation state
                isRotating = false;
                currentSpeed = normalSpeed;

                //provide points when rotation reachs
                ScoreManager.Instance.AddScore(100);

                AudioController.Instance.PlaySFX(0);
            }
        }
        else
        {
            // Check if it's time to start a fast rotation
            if (Time.time % fastDuration < (fastDuration / 2))
            {
                currentSpeed = fastSpeed;
            }
            else
            {
                currentSpeed = normalSpeed;
            }

            // Start a new rotation
            isRotating = true;
            rotationStartTime = Time.time;
        }
    }

    // Method to reset the rotation of the object to its initial rotation
    public void ResetRotation()
    {
        
        transform.rotation = initialRotation;
        isRotating = false;
    }

}
