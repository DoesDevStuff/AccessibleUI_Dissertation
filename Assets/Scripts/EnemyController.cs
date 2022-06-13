using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// we have a finite state machine for the enemy
// best to declare states in an enum

public enum EnemyStates
{
    Chase,
    
    Patrol,

    Die
};

public class EnemyController : MonoBehaviour
{

    GameObject player;
    [SerializeField] EnemyStates currentState = EnemyStates.Patrol;
    [SerializeField] float range = 10f;
    [SerializeField] float speed = 1f;

    private bool _chooseDir = false;
    private bool _dead = false;

    private Vector3 _randomDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case (EnemyStates.Patrol):
                Patrol();
                break;

            case (EnemyStates.Chase):
                Chase();
                break;

            case (EnemyStates.Die):
                Death();
                break;
        }

        if(isPlayerInRange(range) && currentState != EnemyStates.Die)
        {
            currentState = EnemyStates.Chase;
        }
        else if (!isPlayerInRange(range) && currentState != EnemyStates.Die)
        {
            currentState = EnemyStates.Patrol;
        }
    }

    private bool isPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    void Patrol()
    {
        if (!_chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;

        if (isPlayerInRange(range))
        {
            currentState = EnemyStates.Chase;
        }
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private IEnumerator ChooseDirection()
    {
        _chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        _randomDir = new Vector3(0, 0, Random.Range(0, 360));

        Quaternion nextRotation = Quaternion.Euler(_randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        _chooseDir = false;
    }
}
