using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    #region Public properties
    [Header("Player Properties")]
    [SerializeField] float playerSpeed = 5;
    [SerializeField] Text collectedText;

    Rigidbody2D player_rigidbody;

    [Header("Bullet Properties")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 5.5f;
    [SerializeField] float firingDelay = 0.5f;
    #endregion

    #region Private properties
    [Header("Bullet Properties")]
    private float _lastFired;

    #endregion

    [Header("Collectibles")]
    public static int amountCollected = 0;


    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // player movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // shoot inputs
        float shootHorizontal = Input.GetAxis("ShootHorizontal");
        float shootVertical = Input.GetAxis("ShootVertical");

        if((shootHorizontal != 0 || shootVertical != 0) && Time.time > _lastFired + firingDelay)
        {
            Shoot(shootHorizontal, shootVertical);
            _lastFired = Time.time;
        }

        player_rigidbody.velocity = new Vector3(horizontal * playerSpeed, vertical * playerSpeed, 0);
        collectedText.text = "Items Collected: " + amountCollected;


        // item system updates
        firingDelay = GameController.FireRate;
        playerSpeed = GameController.MoveSpeed;

    }

    // method to handle Shooting
    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,    
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,    
            0
        );
    }
}
