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

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 3.4f;
    }
    private void Awake()
    {
        target = GameObject.Find("Target Location").transform;
        StartCoroutine(StuckEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(target.position);

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

    }

    IEnumerator StuckEnemy()
    {
        yield return new WaitForSeconds(25);
        Destroy();
    }

}
