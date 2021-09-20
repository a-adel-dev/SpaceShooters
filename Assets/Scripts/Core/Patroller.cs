using UnityEngine;

namespace Core
{
    public class Patroller : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private float movementSpeed;

        private int _currentWayPoint = 0;

        private void Update()
        {
            Patrol();
        }

        private void Patrol()
        {
            if (wayPoints.Length <= 0) return;

            transform.position = Vector3.MoveTowards(transform.position, wayPoints[_currentWayPoint].position,
                movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, wayPoints[_currentWayPoint].position) <= 0.001f)
            {
                _currentWayPoint++;
                if (_currentWayPoint >= wayPoints.Length)
                {
                    _currentWayPoint = 0;
                }
            }
        }
    }
}