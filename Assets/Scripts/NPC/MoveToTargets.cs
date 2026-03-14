using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveToTargets : MonoBehaviour
{
    [SerializeField] NPC npcComponent;
    [SerializeField] Transform thisTransform;
    [SerializeField] GameObject player;
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    private float speed = 0.8f;
    private float waitTime = 5f;
    private int _target_index = 0;


    void Update()
    {
        if (targets.Count == 0) return;

        Transform target = targets[_target_index].transform;
        Vector3 targetPosition = new Vector3(target.position.x, thisTransform.position.y, target.position.z);

        // If at target then rest
        if (Vector3.Distance(thisTransform.position, targetPosition) < 2f)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0.1f)
            {
                _target_index++;
                waitTime = 5f;
            }

            if (_target_index >= targets.Count)
                _target_index = 0;
        }

        // If not at target then move
        else
        {
            if (npcComponent.GetState() == NPC.NpcState.Idle)
            {
                transform.LookAt(targetPosition);
                thisTransform.position = Vector3.MoveTowards(
                thisTransform.position,
                targetPosition,
                speed * Time.deltaTime
                );
            }
            else
            {
                transform.LookAt(player.transform);
            }
        }
    }
}
