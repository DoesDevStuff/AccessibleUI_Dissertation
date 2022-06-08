using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static int amountCollected = 0;

    [SerializeField] float playerSpeed = 5;
    [SerializeField] Text collectedText;
    
    Rigidbody2D player_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        player_rigidbody.velocity = new Vector3(horizontal * playerSpeed, vertical * playerSpeed, 0);
        collectedText.text = "Items Collected: " + amountCollected;
    }
}
