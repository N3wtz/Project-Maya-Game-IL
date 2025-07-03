using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 3f;
    public Transform target;
    public float xOffset = 0f;

    void Update()
    {
        // Gunakan posisi Y dan Z kamera saat ini
        float fixedY = transform.position.y;
        float fixedZ = transform.position.z;

        // Kamera hanya mengikuti X
        Vector3 newPos = new Vector3(target.position.x + xOffset, fixedY, fixedZ);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
