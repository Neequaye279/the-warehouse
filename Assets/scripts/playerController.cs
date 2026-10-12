using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class playerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;

    public AudioClip pickupClip;

    public GameObject victoryText;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();
        victoryText.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        countText.text = "Keys: " + count;
        if (count >= 6)
        {
            FindFirstObjectByType<Door>().Open();
            enemy.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            enemy.SetActive(false);
            victoryText.SetActive(true);
            victoryText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            other.gameObject.SetActive(false);
            count++;

            setCountText();
        }
    }
}
