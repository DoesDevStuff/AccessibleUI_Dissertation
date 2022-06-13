using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Public properties
    // change this if you want bullet visible for longer time
    [SerializeField] float bullet_lifeTime = 0.5f;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().Death();
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(bullet_lifeTime);
        Destroy(gameObject);

    }
}
