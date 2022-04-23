using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Controller : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    private async void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            //lr.SetPosition(i, points[i].position);
            lr.SetPosition(i, points[i].position + new Vector3(0, 0.3f, 0));

        }
    }
}
