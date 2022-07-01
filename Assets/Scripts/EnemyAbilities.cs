    using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Pooling;
using UnityEngine.Serialization;

public class EnemyAbilities : MonoBehaviour
{
    public ParticleSystem hitPartical;
    public UnityEvent HurtEvent;
    public UnityEvent DeathEvent;
    public UnityEvent playerHurt;
    public IntVariable playerHp;
    public IntVariable enemyCount;
    private AudioSource _audioSource;
    public float speed;
    [SerializeField] private Vector3Variable player;
    private GameObjectSpawner spawner;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    public float attackTimeCooldown;
    private float _attackTimeCooldownTimer;
    public int damage;
    public float MaxHealth;
    private float currentHealth;
    public bool isDeath;
    private float distance;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void OriginWhenSpawn()
    {
        _navMeshAgent.enabled = true;
        isDeath = false;
        currentHealth = MaxHealth;
    }
    private void Start()
    {
        OriginWhenSpawn();
        _audioSource = GetComponent<AudioSource>();
        spawner = FindObjectOfType<GameObjectSpawner>();
        
        _attackTimeCooldownTimer = 0;
        _animator = GetComponent<Animator>();    
    }

    private void Update()
    {
       FollowPlayer();
        //Debug.Log(_attackTimeCooldownTimer);
        if (currentHealth < 0.1)
        {
            Death();
        }
        _attackTimeCooldownTimer += Time.deltaTime;
        speed = _navMeshAgent.velocity.magnitude;
        distance = Vector3.Distance(player.Value,gameObject.transform.position);
        if (distance < 1.5f&&!isDeath)
        {
            if (_attackTimeCooldownTimer>attackTimeCooldown)
            {
                AttackPlayer();
                _attackTimeCooldownTimer = 0;
            }
            
        }
        _animator.SetFloat("Speed",Mathf.Sqrt(speed));
       
    }

    void FollowPlayer()
    {
        if (isDeath)
        {
            _navMeshAgent.enabled = false;
            return;
        }
        _navMeshAgent.destination = player.Value;
    }
    void AttackPlayer()
    {
        if (playerHp.Value <= 0)
        {
            return;
        }
        playerHurt.Invoke();
        playerHp.Value -= damage;
    }
    public void TakeDame(float damage)
    {
        if (currentHealth < 0.1)
        {
            return;
        }
        hitPartical.Play();
        HurtEvent.Invoke();
        currentHealth -= damage;
    }

    private void Death()
    {
        
        isDeath = true;
        DeathEvent.Invoke();
        _animator.SetTrigger("Death");
        StartCoroutine(WaitToReturn(1f));
    }

    IEnumerator WaitToReturn(float time)
    {
        yield return new WaitForSeconds(time);
        //DeathPartical.Stop();
        enemyCount.Value += 1;
        spawner.Return(gameObject);
    }
}
