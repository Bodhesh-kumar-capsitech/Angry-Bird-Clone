using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        startPos = rb.position;

    }
    void OnMouseDown()
    {
        sprite.color = Color.red;
    }
    void OnMouseUp()
    {
        currPos = rb.position;
        direction = startPos - currPos;
        direction.Normalize();
        rb.bodyType = RigidbodyType2D.Dynamic;

        rb.AddForce(speed * direction);

        sprite.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 desirePos = mousePos;

        float distance = Vector2.Distance(desirePos, startPos);

        if (distance > maxDrag)
        {
            direction = desirePos - startPos;
            direction.Normalize();
            desirePos = startPos + (direction * maxDrag);
        }

        if (desirePos.x > startPos.x)
        {
            desirePos.x = startPos.x;
        }

        // transform.position = new Vector3(mousePos.x,mousePos.y,transform.position.z);
        rb.position = desirePos;
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
    }
}
