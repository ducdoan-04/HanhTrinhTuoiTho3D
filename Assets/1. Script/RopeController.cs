using UnityEngine;

public class RopeController : MonoBehaviour
{
    public Transform leftPivot;   // RopePivot_Left
    public Transform rightPivot;  // RopePivot_Right
    public float speed = 150f;    // tốc độ quay (độ/giây)

    private float angle = 0f;
    private float radius;
    private Vector3 center;

    void Start()
    {
        // Tính tâm vòng tròn giữa 2 pivot
        center = (leftPivot.position + rightPivot.position) / 2f;
        radius = Vector3.Distance(leftPivot.position, rightPivot.position) / 2f;
    }

    void Update()
    {
        // Quay theo hình tròn (dùng trục X)
        angle += speed * Time.deltaTime;
        if (angle >= 360f) angle -= 360f;

        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        float z = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;

        // Cập nhật vị trí pivot trái
        leftPivot.localPosition = new Vector3(0, y, z);

        // Pivot phải đối xứng
        rightPivot.localPosition = new Vector3(0, -y, -z);
    }
}
