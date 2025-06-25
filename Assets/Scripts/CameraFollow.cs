using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 3f;
    public Transform target;
    public float xOffset = 0f;
    public float yOffset = 2.4f;
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
