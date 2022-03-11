using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;

    private Rigidbody2D rbody;

    private static readonly int Shoot = Animator.StringToHash("Shoot");
    private float shootDelay = 0.5f;
    private float timepassed = 1f;

    public float movementPerSecond = 10f;


    //-----------------------------------------------------------------------------
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        //shoot continuously
        timepassed += Time.deltaTime;
        if (1f == Input.GetAxis("Fire1"))
        {
            if (timepassed >= shootDelay)
            {
                timepassed = 0f;

                // todo - trigger a "shoot" on the animator
                playerAnimator.SetTrigger(Shoot);

                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                Debug.Log("Bang!");

                Destroy(shot, 3f);
            }
        }

        //move left or right
        float movementAxis;

        movementAxis = Input.GetAxis("Horizontal");

        //Debug.Log(movementAxis);

        if (movementAxis != 0)
        {
            Vector2 force = new Vector2(movementAxis, 0);

            if (rbody)
            {
                rbody.MovePosition(rbody.position + force * Time.fixedDeltaTime * movementPerSecond);
            }
        }
        else 
        {
           rbody.velocity = Vector2.zero;
           rbody.angularVelocity = 0f;
        }

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        // if the player gets hit by an enemy bullet or an enemy
        if (collider.gameObject.tag == "enemybullet" || collider.gameObject.tag == "Callous" || collider.gameObject.tag == "Sore" || collider.gameObject.tag == "Blister")
        {
            playerAnimator.SetTrigger("Destroyed");
            Destroy (gameObject, 1f); 

            GameObject.Find("GameManager").GetComponent<GameManager>().LoadCredits();

            Debug.Log("You lose!");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // if the player gets hit by an enemy bullet or an enemy
        if (collider.gameObject.tag == "enemybullet" || collider.gameObject.tag == "Callous" || collider.gameObject.tag == "Sore" || collider.gameObject.tag == "Blister")
        {
            playerAnimator.SetTrigger("Destroyed");
            Destroy (gameObject, 1f); 

            GameObject.Find("GameManager").GetComponent<GameManager>().LoadCredits();

            Debug.Log("You lose!");
        }
    }
}
