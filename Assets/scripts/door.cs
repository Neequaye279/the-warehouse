using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public Vector3 slideOffset = new Vector3(0f, 0f, -4.2f);
    public float speed = 2f;
    public Transform cam;
    public Transform camPoint;
    public Transform lookTarget;
    public CameraContoller cameraFollow;
    public GameObject winText;
    public NavMeshAgent guard;
    bool open;
    Vector3 target;

    void Start()
    {
        target = transform.localPosition + slideOffset;
    }

    public void Open()
    {
        open = true;
        NavMeshObstacle obstacle = GetComponent<NavMeshObstacle>();
        if (obstacle != null) obstacle.enabled = false;
        if (cameraFollow != null) cameraFollow.enabled = false;
        if (guard != null) guard.isStopped = true;
        if (winText != null) winText.SetActive(true);
    }

    void Update()
    {
        if (!open) return;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);

        if (cam != null && camPoint != null)
        {
            cam.position = Vector3.Lerp(cam.position, camPoint.position, 2f * Time.deltaTime);
            Quaternion look = Quaternion.LookRotation(lookTarget.position - cam.position);
            cam.rotation = Quaternion.Slerp(cam.rotation, look, 3f * Time.deltaTime);
        }
    }
}