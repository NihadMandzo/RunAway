using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public int maxHealth = 4;
    public int currentHealth = 4;
    [SerializeField] float AttackRange = 1f;
    [SerializeField] float AggroRange = 4f;

    public GameObject player;
    NavMeshAgent _agent;
    Animator _animator;
    private bool isPlayerFound = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth<0)
        {
            return;
        }
        if(isPlayerFound)
            _agent.SetDestination(player.transform.position);
        _animator.SetFloat("Speed", _agent.velocity.magnitude/_agent.speed);
        if ((Vector3.Distance(player.transform.position, transform.position)<=AggroRange && Vector3.Distance(player.transform.position, transform.position)>AttackRange))
        {
            _animator.SetBool("AttackConst", false);
            _animator.SetTrigger("InRange");
            isPlayerFound = true;
            var lookPos = player.transform.position - this.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
        if (Vector3.Distance(player.transform.position, transform.position) <= AttackRange)
        {
            _animator.SetBool("AttackConst", true);
            _animator.SetTrigger("Attack");
            
            var lookPos = player.transform.position - this.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
            
        }
        else
        {
            _animator.SetBool("AttackConst", false);
            _animator.ResetTrigger("Attack");
        }
    }
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth<=0)
        {
            _animator.SetBool("AttackConst", false);
            _animator.ResetTrigger("Attack");
            _animator.ResetTrigger("InRange");
            if (damage==2)
            { 
                _animator.SetTrigger("HeadShot");
            }
            else
            {
                _animator.SetTrigger("BodyShot");
            }

            Die();

        }
    }

    public void Die()
    {
        
        Destroy(this.gameObject, 1.5f);
    }

    
}
