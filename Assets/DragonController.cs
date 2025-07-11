using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;

    private void Start()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidBody = GetComponent<Rigidbody>();

        if (rigidBody.isKinematic)
        {
            Debug.LogWarning("Rigidbody is set as Kinematic! Velocity won't affect the object.");
        }
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal);

        if(movement.magnitude > 0.1f)
        {
            rigidBody.velocity = movement.normalized * speed;

            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.2f);
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
        }
    }
}
