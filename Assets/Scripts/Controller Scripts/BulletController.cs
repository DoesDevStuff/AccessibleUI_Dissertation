using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Public properties
    // change this if you want bullet visible for longer time
    [SerializeField] float bullet_lifeTime = 0.5f;

    public bool isEnemyBullet = false;

    #endregion

    #region Private Properties

    private Vector2 _lastPos;
    private Vector2 _curPos;
    private Vector2 _playerPos;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
        if (!isEnemyBullet)
        {
            transform.localScale = new Vector2(GameController.BulletSize, GameController.BulletSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyBullet)
        {
            _curPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, _playerPos, 5f * Time.deltaTime);
            if (_curPos == _lastPos)
            {
                Destroy(gameObject);
            }
            _lastPos = _curPos;
        }
    }

    public void GetPlayer(Transform player)
    {
        _playerPos = player.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && !isEnemyBullet)
        {
            collision.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }

        if(collision.tag == "Player" && isEnemyBullet)
        {
            GameController.DamagePlayer(1);
            Destroy(gameObject);
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(bullet_lifeTime);
        Destroy(gameObject);

    }
}
