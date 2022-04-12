using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public float power;
    public Vector2 minPower;
    public Vector2 maxPower;

    //public Camera cam;

    private Vector2 force;
    private Vector3 start;
    private Vector3 end;
    private Rigidbody2D rb;
    private bool pressed;

    private Trajectory tline;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        tline = GetComponent<Trajectory>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            start.z = 15f;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 curr = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curr.z = 15f;
            tline.RenderLine(start, curr);
        }

        if (Input.GetMouseButtonUp(0))
        {
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            end.z = 15f;

            force = new Vector2(Mathf.Clamp(start.x - end.x, minPower.x, maxPower.x), Mathf.Clamp(start.y - end.y, minPower.y, maxPower.y));

            rb.AddForce(force * power, ForceMode2D.Impulse);
            tline.EndLine();
        }
    }

}
