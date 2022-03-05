using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Points : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Line_Script lines;
    void Start()
    {
        lines.SetUpLine(points);
    }
}
