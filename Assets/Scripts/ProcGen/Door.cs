using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorType
    {
        left, right, top, bottom
    }

    public DoorType doorType;

    public GameObject doorCollider;

    private GameObject _player;
    private float _widthOffset = 1.75f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (doorType)
            {
                case DoorType.bottom:
                    _player.transform.position = new Vector2(transform.position.x, transform.position.y - _widthOffset);
                    break;
                case DoorType.left:
                    _player.transform.position = new Vector2(transform.position.x - _widthOffset, transform.position.y);
                    break;
                case DoorType.right:
                    _player.transform.position = new Vector2(transform.position.x + _widthOffset, transform.position.y);
                    break;
                case DoorType.top:
                    _player.transform.position = new Vector2(transform.position.x, transform.position.y + _widthOffset);
                    break;
            }
        }
    }
}
