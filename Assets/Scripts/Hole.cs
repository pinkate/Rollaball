using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Hole : MonoBehaviour
{

    private Rigidbody rb;
    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;

    // UI object to display winning text.
    public GameObject winTextObject;

    // Variable to keep track of collected "PickUp" objects.
    static int count;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize count to zero.
        count = 0;

        // Update the count display.
        SetCountText();

        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            count = count + 1;

            // Update the count display.
            SetCountText();
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.transform.position = new Vector3((float)0, (float)0.5, (float)0);
            // 位置(0, 0.5, 0)
            rb = other.gameObject.GetComponent<Rigidbody>();
            //取得剛體
            rb.velocity = Vector3.zero;
            //移動速度=0
            rb.angularVelocity = Vector3.zero;
            //旋轉速度=0

            // Increment the count of "PickUp" objects collected.
            count = count - 1;

            // Update the count display.
            SetCountText();
        }
    }

    void SetCountText()
    {
        // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();

        // Check if the count has reached or exceeded the win condition.
        if (count >= 9)
        {
            // Display the win text.
            winTextObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
