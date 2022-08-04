using UnityEngine;

namespace Platforms
{
    public class SpawnPlatform : Platform
    {
        [SerializeField] private Ball.Ball ball;
        [SerializeField] private Transform spawnPoint;

        private void Awake()
        {
            Instantiate(ball, spawnPoint.position, Quaternion.identity);
        }
    }
}
