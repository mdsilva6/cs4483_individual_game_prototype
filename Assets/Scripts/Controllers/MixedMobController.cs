using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class MixedMobController : MonoBehaviour
{
    public float lookRadius = 5f;

    Transform target;

    NavMeshAgent agent;

    CharacterCombat combat;

    Enemy thisMob;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        thisMob = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= lookRadius && thisMob.isInteracting)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                FaceTarget();

            }
        }
        else
        {
            Debug.LogError("transform.position is null");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
