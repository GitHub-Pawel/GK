using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensivity = 50f;
    [SerializeField]
    public Transform player, head;
    float xRotation = 0f;
    public bool shouldILook = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!shouldILook)
        {
            return;
        }
            
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 60f);

        transform.localRotation = Quaternion.Euler(0f, xRotation, 90f);
       
        player.Rotate(Vector3.up * mouseX);
    }
}
