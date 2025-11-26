using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 startPos;
    private Vector2 currPos;
    private Vector2 direction;
    [SerializeField] private float speed = 40.0f;
    [SerializeField] private float maxDrag = 2.0f;
    private float downRange = 7.2f;
    private float rightRange = 39.0f;
    private float leftRange = 14.0f;
    private TrajectoryPredictor predict;
    private Vector2 predictPos;
    private CameraController controller;
    public bool isDragging = false;
    private int maxBirdSpawnCount = 5;
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
    void Update()
    {
        if(transform.position.y < -downRange || transform.position.x > rightRange || transform.position.x < -leftRange)
        {
            StartCoroutine(Resetdelay());
        }

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
        rb.bodyType = RigidbodyType2D.Dynamic;
        // rb.AddForce(speed * direction);
        rb.linearVelocity = speed * direction;
        sprite.color = Color.white;
        predict.Hide();
    }

   void OnMouseDrag()
   {
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(isDragging == true)
        {
            SlingshotRubber.instance.DrawBands();
        }     
    // Calculate direction and distance
     direction = mousePos - startPos;
    float distance = Vector2.Distance(mousePos,startPos);

    // Clamp distance
    float clampedDistance = Mathf.Clamp(distance, 0, maxDrag);

    Vector2 desirePos = startPos + direction.normalized * clampedDistance;

    desirePos.x = Mathf.Min(desirePos.x, startPos.x);

    rb.position = desirePos;

    Vector2 launchDirection = startPos - desirePos;
    // Vector3 velocity = (launchDirection * speed)/rb.mass * Time.fixedDeltaTime;
    Vector3 velocity = launchDirection * speed;
    predict.DrawTrajectory(rb.position,velocity,rb.gravityScale);

   }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // birdSpawnCount ++;
        // print("Bird spawn count is: " + birdSpawnCount);
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
