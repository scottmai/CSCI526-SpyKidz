using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    // Update is called once per frame
    public void RenderLine(Vector3 start, Vector3 end)
    {
        line.positionCount = 2;

        Vector3[] points = new Vector3[2];
        points[0] = start;
        points[1] = end;

        line.SetPositions(points);
    }

    public void EndLine()
    {
        line.positionCount = 0;
    }
}
