using UnityEngine; 
public class PlatformMovement : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private float movementSpeed = 1.5f;
    private bool flag = false;
    Vector3 startPosition = Vector3.zero;

    [SerializeField] float offsetLeft = -2, offsetRight = 2;
    [SerializeField] bool hasReachedRight = true, hasReachedLeft = false;

    void Awake() {
        startPosition = platform.transform.position;
        print(startPosition);
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1" | other.gameObject.name == "Player2")
        {
            flag = true;
            print("Move");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag) {

            
            /*
            print(hasReachedLeft);
            print(hasReachedRight);
            print(System.Math.Round(platform.transform.position.x, 2));
            print(System.Math.Round(startPosition.x - offsetLeft, 2));
            */

            if (System.Math.Round(platform.transform.position.x, 2) == System.Math.Round(startPosition.x - offsetLeft, 2))
            {
                hasReachedLeft = true;
                hasReachedRight = false;

            }
            if (System.Math.Round(platform.transform.position.x, 2) == System.Math.Round(startPosition.x, 2))
            {
                hasReachedLeft = false;
                hasReachedRight = true; 

            }
            if (System.Math.Round(platform.transform.position.x, 2) >= System.Math.Round(startPosition.x - offsetLeft, 2) && !hasReachedLeft)
             {
                 // print("Left");
                 platform.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
             }

            
            if (System.Math.Round(platform.transform.position.x, 2) <= System.Math.Round(startPosition.x, 2) && !hasReachedRight) {
                // print("Right");
                platform.transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));

             }
        }         
    }
}
