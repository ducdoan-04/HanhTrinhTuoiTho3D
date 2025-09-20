using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeLine : MonoBehaviour
{
    public Transform startPoint; // Tay trái bot
    public Transform endPoint;   // Tay phải bot
    public int segmentCount = 20; // số điểm chia dây

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segmentCount + 1;
    }

    void Update()
    {
        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;

            // Lerp từ tay trái sang tay phải
            Vector3 pos = Vector3.Lerp(startPoint.position, endPoint.position, t);

            // Thêm độ võng xuống cho dây (parabol)
            float sag = Mathf.Sin(t * Mathf.PI) * 0.9f; 
            pos.y -= sag;

            line.SetPosition(i, pos);
        }
    }
}
