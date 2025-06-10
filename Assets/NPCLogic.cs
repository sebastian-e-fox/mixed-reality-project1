using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class NPCLogic : MonoBehaviour
{
    [Header("Navigation")]
    public NavMeshAgent _agent;
    public Transform target;
    public float closeDistance = 2.5f;
    public bool closeToTarget = false;
    public bool death = false;

    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 3.4f;
    }
    private void Awake()
    {
        target = GameObject.Find("Target Location").transform;
        _anim = GetComponent<Animator>();
        StartCoroutine(StuckEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (!death)
        {
            _agent.SetDestination(target.position);
        }
        /* else // TESTING
        {
            Shot();
        } */

        if (Vector3.Distance(transform.position, target.position) < closeDistance)
        {
            closeToTarget = true;
            Destroy();
        }

    }

    void Destroy()
    {
        Destroy(gameObject);
        EnemyManager.EnemyDied();
    }

    public void Shot()
    {
        death = true;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        _anim.SetBool("Death", true);
        StartCoroutine(DeathWait());
    }

    IEnumerator StuckEnemy()
    {
        yield return new WaitForSeconds(30);
        Destroy();
    }
    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(7);
        Destroy();
    }
}
