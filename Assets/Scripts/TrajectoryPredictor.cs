using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour
{

    [SerializeField]private LineRenderer line;
    [SerializeField]private int pointCount = 30;
    [SerializeField]private float spacing = 0.1f;
    public static TrajectoryPredictor instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }
    public void DrawTrajectory(Vector2 startPos,Vector2 startVelocity)
    {
        float gravityScale = 1.0f;
        line.positionCount = pointCount;
            Vector2 g = Physics2D.gravity * gravityScale;
        for(int i=0;i< pointCount;i++)
        {
            float t = i * spacing;
            Vector2 point = startPos + startVelocity * t + 0.5f * g * (t * t);
            line.SetPosition(i,point);
        }
    }
    public void Hide()
    {
        line.positionCount = 0;
    }
}
