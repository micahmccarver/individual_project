using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text winText2;

    private Rigidbody rb;
    private int count;
    private int finalcount;
    private int holecount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        holecount = 0;
        finalcount = 0;
        SetCountText();
        winText.text = "";
        winText2.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            if (holecount == 1)
            {
                finalcount = count;

            }
            else
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
        }

        if (other.gameObject.CompareTag("Hole"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            holecount = holecount + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Pts: " + count.ToString();
        if (holecount == 1)
        {
            winText.text = "It's in!";
            
        }

        if (holecount == 1)
        {
            finalcount = count;
            winText2.text = "Final Score: " + finalcount.ToString(); ;

        }
    }
}