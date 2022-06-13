using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    #region Public properties
    public static GameController instance; // setting up the singleton

    //public List<string> collectedNames = new List<string>();

    public Text healthText;

    #endregion

    #region Private properties

    private static int _maxHealth = 6;
    private static float _health = 6f;
    private static float _moveSpeed = 5f;
    private static float _fireRate = 0.5f;
    private static float _bulletSize = 0.5f;

    // collectible
    private bool _bootCollected = false;
    private bool _screwCollected = false;

    #endregion

    #region getter setter
    public static float Health { get => _health; set => _health = value; }
    public static int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public static float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public static float FireRate { get => _fireRate; set => _fireRate = value; }
    public static float BulletSize { get => _bulletSize; set => _bulletSize = value; }
    #endregion


    private void Awake()
    {
        if(instance == null)
        {
            instance = this; // instantiated
        }
    }

    void Update()
    {
        healthText.text = "Health: " + _health;
    }

    public static void DamagePlayer(int damage)
    {
        _health -= damage;

        if (Health <= 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(float healAmount)
    {
        _health = Mathf.Min(_maxHealth, _health + healAmount);
    }

    public static void MoveSpeedChange(float speed)
    {
        _moveSpeed += speed;
    }

    public static void FireRateChange(float rate)
    {
        _fireRate -= rate;
    }
    public static void BulletSizeChange(float size)
    {
        _bulletSize += size;
    }
    /*
    public void UpdateCollectedItems(CollectibleController item)
    {
        collectedNames.Add(item.item.name);

        foreach (string i in collectedNames)
        {
            switch (i)
            {
                case "Boot":
                    _bootCollected = true;
                    break;
                case "Screw":
                    _screwCollected = true;
                    break;
            }
        }

        if (_bootCollected && _screwCollected)
        {
            FireRateChange(0.25f);
        }
    }
    */
    private static void KillPlayer()
    {

    }
}
