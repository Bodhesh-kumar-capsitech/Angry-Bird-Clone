using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector3 startPos;
    private Vector3 currPos;
    private Vector3 direction;
    [SerializeField] private float speed = 800.0f;
    [SerializeField] private float maxDrag = 4.0f;
    private TrajectoryPredictor predict;
    private Vector2 predictPos;
    private CameraController controller;
    public bool isDragging = false;
    public static BirdController instance;
    void Awake()
    {
        instance = this;
        controller = CameraController.instance;
        predict = TrajectoryPredictor.instance;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        startPos = rb.position;
        predictPos = transform.position;

    }
    void OnMouseDown()
    {
        isDragging = true;
        sprite.color = Color.red;
    }
    void OnMouseUp()
    {
        isDragging = false;
        SlingshotRubber.instance.HideBands();
        currPos = rb.position;
        direction = startPos - currPos;
        direction.Normalize();
        rb.bodyType = RigidbodyType2D.Dynamic;

        rb.AddForce(speed * direction);

        sprite.color = Color.white;
        predict.Hide();
    }

   void OnMouseDrag()
   {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0;

        if(isDragging == true)
        {
            SlingshotRubber.instance.DrawBands();
        }     
    // Calculate direction and distance
     direction = mousePos - startPos;
    float distance = Vector2.Distance(mousePos,startPos);

    // Clamp distance
    float clampedDistance = Mathf.Clamp(distance, 0, maxDrag);

    Vector3 desirePos = startPos + direction.normalized * clampedDistance;

    desirePos.x = Mathf.Min(desirePos.x, startPos.x);

    rb.position = desirePos;

    Vector3 launchDirection = startPos - desirePos;
    Vector3 velocity = (launchDirection * speed)/rb.mass * Time.fixedDeltaTime;
    predict.DrawTrajectory(rb.position,velocity);
        print("Start position is: " + desirePos);

   }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Resetdelay());
    }

    private IEnumerator Resetdelay()
    {
        yield return new WaitForSeconds(2.0f);
        rb.position = startPos;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        controller.ResetCamera();
    }
}
