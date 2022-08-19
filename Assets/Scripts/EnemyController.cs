using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// we have a finite state machine for the enemy
// best to declare states in an enum

public enum EnemyStates
{
    Idle,

    Chase,
    
    Patrol,

    Attack,

    Die
};

public enum EnemyType
{
    Melee,

    Ranged
};

public class EnemyController : MonoBehaviour
{
    #region Public properties
    GameObject player;
    public GameObject bulletPrefab;

    

    [SerializeField] EnemyStates currentState = EnemyStates.Patrol;
    [SerializeField] EnemyType enemyType;

    [SerializeField] float range = 10f;
    [SerializeField] float speed = 1f;
    [SerializeField] float attackingRange = 1f;
    [SerializeField] float bulletSpeed;
    [SerializeField] float coolDown = 2f;


    public bool notInRoom = false;
    #endregion

    #region Private properties
    private bool _chooseDir = false;
    private bool _dead = false;
    private bool _coolDownAttack = false;

    private Vector3 _randomDir;
    #endregion

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
            //case(EnemyStates.Idle):
            //    Idle();
            //break;

            case (EnemyStates.Patrol):
                Patrol();
                break;

            case (EnemyStates.Chase):
                Chase();
                break;

            case (EnemyStates.Attack):
                Attack();
                break;

            case (EnemyStates.Die):
                //Death();
                break;
        }

        if (!notInRoom)
        {
            if (isPlayerInRange(range) && currentState != EnemyStates.Die)
            {
                currentState = EnemyStates.Chase;
            }
            else if (!isPlayerInRange(range) && currentState != EnemyStates.Die)
            {
                currentState = EnemyStates.Patrol;
            }
            if (Vector3.Distance(transform.position, player.transform.position) <= attackingRange)
            {
                currentState = EnemyStates.Attack;
            }
        }
        else
        {
            currentState = EnemyStates.Idle;
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

    void Attack()
    {
        if (!_coolDownAttack)
        {
            switch (enemyType)
            {
                case (EnemyType.Melee):
                    GameController.DamagePlayer(1);
                    StartCoroutine(CoolDown());
                    break;
                case (EnemyType.Ranged):
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                    bullet.GetComponent<BulletController>().GetPlayer(player.transform);
                    bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                    bullet.GetComponent<BulletController>().isEnemyBullet = true;
                    StartCoroutine(CoolDown());
                    break;
            }
        }
    }

    public void Death()
    {
        RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
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

    private IEnumerator CoolDown()
    {
        _coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        _coolDownAttack = false;
    }
}
