using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pooling;
using UnityEngine.Serialization;

public class EnemyAbilities : MonoBehaviour
{
    public ParticleSystem hitPartical;
    public ParticleSystem DeathPartical;
    public AudioClip HurtAudioClip;
    public AudioClip DeathAudioClip;
    private AudioSource _audioSource;
    public float speed;
    [FormerlySerializedAs("playerPosition")] public GameObject player;
    private GameObjectSpawner spawner;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    public float attackTimeCooldown;
    private float _attackTimeCooldown;
    public float damage;
    public float MaxHealth;
    private float currentHealth;
    bool isDeath;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void OriginWhenSpawn()
    {
        _navMeshAgent.isStopped = false;
        isDeath = false;
        currentHealth = MaxHealth;
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        spawner = FindObjectOfType<GameObjectSpawner>();
        
        _attackTimeCooldown = 0;
        player = GameObject.Find("Player");
        _animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        //Debug.Log(_attackTimeCooldown);
        if (currentHealth < 0.1)
        {
            Death();
        }
        _attackTimeCooldown += Time.deltaTime;
        speed = _navMeshAgent.velocity.magnitude;
        if (speed ==0&&!isDeath)
        {
            AttackPlayer();
        }
        _animator.SetFloat("Speed",Mathf.Sqrt(speed));
        _navMeshAgent.destination=player.gameObject.transform.position;
    }

    void AttackPlayer()
    {
        if (_attackTimeCooldown < 5)
        {
            return;
        }
        player.GetComponent<PlayerMovement>().TakeDame(damage);
        _attackTimeCooldown = 0;
        
    }

    public void TakeDame(float damage)
    {
        if (currentHealth < 0.1)
        {
            return;
        }
        hitPartical.Play();
        _audioSource.clip = HurtAudioClip;
        _audioSource.Play();
        currentHealth -= damage;
    }

    public void Death()
    {
        isDeath = true;
       // DeathPartical.Play();
        _audioSource.PlayOneShot(DeathAudioClip);
        _navMeshAgent.isStopped = true;
        _animator.SetTrigger("Death");
        StartCoroutine(WaitToReturn(2f));
    }

    IEnumerator WaitToReturn(float time)
    {
        yield return new WaitForSeconds(time);
        //DeathPartical.Stop();
        spawner.Return(gameObject);
    }
}
