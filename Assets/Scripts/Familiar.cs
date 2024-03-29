﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    public FamiliarData familiar;

    private GameObject _player;
    private float _lastFire; 
    private float _lastOffsetX;
    private float _lastOffsetY;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVert = Input.GetAxis("ShootVertical");
        if ((shootHor != 0 || shootVert != 0) && Time.time > _lastFire + familiar.fireDelay)
        {
            Shoot(shootHor, shootVert);
            _lastFire = Time.time;
        }

        if (horizontal != 0 || vertical != 0)
        {
            float offsetX = (horizontal < 0) ? Mathf.Floor(horizontal) : Mathf.Ceil(horizontal);
            float offsetY = (vertical < 0) ? Mathf.Floor(vertical) : Mathf.Ceil(vertical);
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, familiar.speed * Time.deltaTime);
            _lastOffsetX = offsetX;
            _lastOffsetY = offsetY;
        }
        else
        {
            if (!(transform.position.x < _lastOffsetX + 0.5f) || !(transform.position.y < _lastOffsetY + 0.5f))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(_player.transform.position.x - _lastOffsetX, _player.transform.position.y - _lastOffsetY), familiar.speed * Time.deltaTime);
            }
        }
    }

    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(familiar.bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        float posX = (x < 0) ? Mathf.Floor(x) * familiar.speed : Mathf.Ceil(x) * familiar.speed;
        float posY = (y < 0) ? Mathf.Floor(y) * familiar.speed : Mathf.Ceil(y) * familiar.speed;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(posX, posY);
    }
}
