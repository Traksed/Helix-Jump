using Platforms;
using UnityEngine;

namespace Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private int levelCount;
        [SerializeField] private GameObject beam;
        [SerializeField] private SpawnPlatform spawnPlatform;
        [SerializeField] private Platform[] platforms;
        [SerializeField] private FinishPlatform finishPlatform;
        [SerializeField] private float additionalScale;

        private const float StartAndFinishAdditionalScale = 0.5f;


        private float BeamScaleY => levelCount / 2f + StartAndFinishAdditionalScale + additionalScale / 2f;

        private void Awake()
        {
            Build();
        }

        private void Build()
        {
            var localBeam = Instantiate(beam, transform);
            localBeam.transform.localScale = new Vector3(1, BeamScaleY, 1);
            var spawnPosition = localBeam.transform.position;
            spawnPosition.y += localBeam.transform.localScale.y - additionalScale - 0.3f;
        
            SpawnPlatform(spawnPlatform, ref spawnPosition, localBeam.transform);
        
            for (var i = 0; i < levelCount; i++)
            {
                SpawnPlatform(platforms[Random.Range(0, platforms.Length)], ref spawnPosition, localBeam.transform);
            }
        
            SpawnPlatform(finishPlatform, ref spawnPosition, localBeam.transform);   
        }

        private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
        {
            Instantiate(platform, spawnPosition, Quaternion.Euler(0,Random.Range(0,360),0), parent);
            spawnPosition.y--;
        }
    }
}
