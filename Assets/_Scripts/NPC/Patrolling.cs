using UnityEngine;

namespace NPC
{
    public class Patrolling : MonoBehaviour
    {
        private bool isStanding = false;
        [SerializeField] private float maxStandTime = 5f;
        [SerializeField] private float maxWaitTime = 2.5f;
        [SerializeField] private float minStandTime = 2f;
        [SerializeField] private float minWaitTime = 1f;
        [SerializeField] private float speed = 3f;        // Movement speed
        private float standTimer = 0f;

        // Minimum time to wait before changing direction
        // Maximum time to wait before changing direction
        [SerializeField] private Vector3 targetDirection;
        [SerializeField] private float waitTimer = 0f;
          // Minimum time to stand still
          // Maximum time to stand still

        private void Update()
        {
            if (isStanding)
            {
                standTimer -= Time.deltaTime;
                if (standTimer <= 0)
                {
                    isStanding = false;
                    waitTimer = Random.Range(minWaitTime, maxWaitTime); // Set a new wait timer for direction change
                }
            }
            else
            {
                waitTimer -= Time.deltaTime;
                transform.parent.position += speed * Time.deltaTime * targetDirection;
                if (waitTimer <= 0)
                {
                    // Generate a new random direction
                    targetDirection = Random.onUnitSphere;
                    isStanding = true;
                    standTimer = Random.Range(minStandTime, maxStandTime);
                }

                // Move towards the target direction
            }
        }
    }
}