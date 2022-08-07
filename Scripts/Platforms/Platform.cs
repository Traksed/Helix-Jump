using UnityEngine;

namespace Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float bounceForce;
        [SerializeField] private float bounceRadius;

        public void Break()
        {
            PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();
            foreach (var segment in platformSegments)
            {
                segment.Bounce(bounceForce, transform.position, bounceRadius);
            }
        }
        public void Finish()
        {
            Debug.Log("Finish is True");
        }
    }
}
