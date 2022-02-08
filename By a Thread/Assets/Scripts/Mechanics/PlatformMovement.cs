using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private float movementSpeed = 2f;
    private bool flag = false;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1" | other.gameObject.name == "Player2")
        {
            flag = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (platform.transform.position.x >= 15.0f)
            {
                platform.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
            }
        }
    }
}
