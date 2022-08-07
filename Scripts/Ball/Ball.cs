using Platforms;
using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
           
            if (other.TryGetComponent(out PlatformSegment platformSegment))
            {
                other.GetComponentInParent<Platform>().Break();
                Debug.Log(other);
            }
            else if (other.TryGetComponent(out FinishPlatformSegment finishPlatformSegment))
            {
                other.GetComponentInParent<Platform>().Finish();
                Debug.Log("Finished Successfully");
            }
        }
    }
}
