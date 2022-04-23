using UnityEngine;

public class Tether : MonoBehaviour
{
    public Rigidbody2D bind;

    public HingeJoint2D player2;

    /*public GameObject tetherPrefab;

    public int tethers = 10;

    void Start()
    {
        GenerateTether();
    }

    void GenerateTether ()
    {
        Rigidbody2D previousTether = bind;
        for(int i = 0; i < tethers; i++)
        {
            GameObject tether = Instantiate(tetherPrefab, transform);
            HingeJoint2D joint = tether.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousTether;

            previousTether = tether.GetComponent<Rigidbody2D>();
        }

        player2.connectedBody = previousTether;
        SpriteRenderer sr = previousTether.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }*/


}
