using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeSpin : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public Animator botAnimator;   // Animator bot quay tay
    public int segments = 50;      // càng nhiều thì dây càng mượt
    public float radius = 2f;      // bán kính vòng cung 1.5
    public float speed = 1f;       // tốc độ quay 0.5

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments;
    }

void Update()
{
    if (leftHand == null || rightHand == null || botAnimator == null) return;

    // Vị trí hai tay
    Vector3 start = leftHand.position;
    Vector3 end = rightHand.position;

    // Tâm giữa 2 tay
    Vector3 center = (start + end) * 0.5f;

    // Vector nối hai tay
    Vector3 dir = (end - start).normalized;

    // Trục vuông góc để quay
    Vector3 up = Vector3.up;
    Vector3 axis = Vector3.Cross(dir, up).normalized;

    // Thời gian → góc quay
    float animTime = botAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime * speed;
    float angle = animTime * Mathf.PI * 2;

    for (int i = 0; i < segments; i++)
    {
        float t = (float)i / (segments - 1);
        Vector3 pos = Vector3.Lerp(start, end, t);

        // Dùng cả sin + cos để tạo vòng tròn đầy đủ
        float sin = Mathf.Sin(angle);
        float cos = Mathf.Cos(angle);

        // lên xuống theo sin, ra vào theo cos
        pos += axis * sin * Mathf.Sin(t * Mathf.PI) * radius;
        pos += Vector3.up * cos * Mathf.Sin(t * Mathf.PI) * radius;

        line.SetPosition(i, pos);
    }
}

}
