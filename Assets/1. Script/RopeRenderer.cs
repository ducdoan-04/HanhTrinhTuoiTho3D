using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeRenderer : MonoBehaviour
{
    public Transform[] ropeSegments;  // drag các segment vào
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = ropeSegments.Length;
    }

    void Update()
    {
        for (int i = 0; i < ropeSegments.Length; i++)
        {
            line.SetPosition(i, ropeSegments[i].position);
        }
    }
}
