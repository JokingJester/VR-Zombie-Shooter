 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public bool YouDied;
    public bool ChasePlayer;


    private NavMeshAgent _agent;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _playerDistance;
 

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
        _anim = transform.Find("Man_01_Dismembered").GetComponent<Animator>();
        _target = GameObject.Find("Player").GetComponent<Transform>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _agent.avoidancePriority = Random.Range(0, 50);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Vector3.Distance(_player.transform.position, this.transform.position) < _playerDistance)
        {
            
            ChasePlayer = true;
        }

        if (ChasePlayer == true)
        {
            _agent.SetDestination(_target.position);
        }

        if (_agent.velocity.magnitude > 0.1f)
        {
            _anim.SetBool("Walk", true);
        }
        
        if (_agent.velocity.magnitude < 0.1f)
        {
            _anim.SetBool("Walk", false);
        }

        if (_agent.remainingDistance < 1.5f)
        {
            _anim.SetBool("Attack", true);
            _agent.speed = 0;
        }

        if (_agent.remainingDistance >= 1.5f)
        {
            _anim.SetBool("Attack", false);
            _agent.speed = Speed; 
        }

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_Death"))
        {
            Speed = 0;
            StartCoroutine(DestroyZombie());
        }

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_Death_Prone"))
        {
            Speed = 0;
            StartCoroutine(DestroyZombie());
        }
    }

    IEnumerator DestroyZombie()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }
}
