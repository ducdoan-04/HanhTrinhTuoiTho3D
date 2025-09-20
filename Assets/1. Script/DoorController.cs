using UnityEngine;
using UnityEngine.InputSystem; // nếu dùng Input System mới

public class DoorController : MonoBehaviour
{
    public Transform leftDoorPivot;
    public Transform rightDoorPivot;
    public float openAngle = 169f;
    public float speed = 2f;

    private bool isOpen = false;
    private bool isPlayerNear = false; // chỉ true khi player trong trigger

    private Quaternion leftClosedRot, leftOpenRot;
    private Quaternion rightClosedRot, rightOpenRot;

    void Start()
    {
        leftClosedRot = leftDoorPivot.localRotation;
        rightClosedRot = rightDoorPivot.localRotation;

        leftOpenRot = leftClosedRot * Quaternion.Euler(0, openAngle, 0);
        rightOpenRot = rightClosedRot * Quaternion.Euler(0, -openAngle, 0);
    }

    void Update()
    {
        if (isPlayerNear && Keyboard.current.eKey.wasPressedThisFrame) // chỉ khi gần cửa
        {
            isOpen = !isOpen;
        }

        if (isOpen)
        {
            leftDoorPivot.localRotation = Quaternion.Slerp(leftDoorPivot.localRotation, leftOpenRot, Time.deltaTime * speed);
            rightDoorPivot.localRotation = Quaternion.Slerp(rightDoorPivot.localRotation, rightOpenRot, Time.deltaTime * speed);
        }
        else
        {
            leftDoorPivot.localRotation = Quaternion.Slerp(leftDoorPivot.localRotation, leftClosedRot, Time.deltaTime * speed);
            rightDoorPivot.localRotation = Quaternion.Slerp(rightDoorPivot.localRotation, rightClosedRot, Time.deltaTime * speed);
        }
    }

    // Khi player bước vào trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    // Khi player rời khỏi trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
