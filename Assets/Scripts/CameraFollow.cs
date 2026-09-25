using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float offsetZ = 5f;
    public bool useSmoothing = true;
    private float fixedYPosition;
    private float fixedXPosition;

    void Start()
    {
        fixedYPosition = transform.position.y;
        fixedXPosition = transform.position.x;
    }
    void LateUpdate()
    {
        if (target == null) return;
        float desiredZPosition = target.position.z - offsetZ;
        Vector3 targetPosition = new Vector3(fixedXPosition, fixedYPosition, desiredZPosition);

        if (useSmoothing)
        {
           transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = targetPosition;
        }
    }

}
