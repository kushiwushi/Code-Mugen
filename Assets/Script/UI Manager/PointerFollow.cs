using UnityEngine;

public class PointerFollow : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    [SerializeField] private BuffUIController buffUIController;

    void Awake() {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (!buffUIController.IsPaused)
        {
            AimMousePoint();
        }
    }

    public void AimMousePoint() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
