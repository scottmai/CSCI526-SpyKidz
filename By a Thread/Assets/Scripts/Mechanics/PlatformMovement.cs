using UnityEngine;
public class PlatformMovement : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;

    private float movementSpeed = 1.5f;
    private bool flag = false;
    Vector3 startPosition = Vector3.zero;

    private float offsetLeft = 3, offsetRight = 3;
    private bool hasReachedRight = true, hasReachedLeft = false;

    private LifeManager lifeManager;

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
            gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        lifeManager = FindObjectOfType<LifeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //upon death, reset flag and platform position
        if (lifeManager.GameOver())
        {
            // print("reset platform");
            flag = false;
            platform.transform.position = (startPosition);
            platform.SetActive(true);
        }

        if (flag) {


            /*
            print(hasReachedLeft);
            print(hasReachedRight);
            print(startPosition.x);
            print(System.Math.Round(platform.transform.position.x, 2));
            print(System.Math.Round(startPosition.x - offsetLeft, 2));
            */

            if (System.Math.Round(platform.transform.position.x, 2) <= System.Math.Round(startPosition.x - offsetLeft, 2))
            {
                hasReachedLeft = true;
                hasReachedRight = false;

            }
            if (System.Math.Round(platform.transform.position.x, 2) >= System.Math.Round(startPosition.x, 2))
            {
                hasReachedLeft = false;
                hasReachedRight = true;

            }
            if (!hasReachedLeft)
             {
                // print("Left");

                 platform.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
             }


            if (!hasReachedRight) {
                print("Right");
                platform.transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));

             }
        }
    }
}
