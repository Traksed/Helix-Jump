using UnityEngine;

namespace Ball
{
    public class BallTracking : MonoBehaviour
    {
        [SerializeField] private Vector3 directionOffset;
        [SerializeField] private float lenght;
        
        private Ball _ball;
        private Beam _beam;
        private Vector3 _cameraPosition;
        private Vector3 _minimumBallPosition;


        private void Start()
        {
            _ball = FindObjectOfType<Ball>();
            _beam = FindObjectOfType<Beam>();

            _cameraPosition = _ball.transform.position;
            _minimumBallPosition = _cameraPosition;
            
            TrackBall();
        }

        private void Update()
        {
            if (_ball.transform.position.y < _minimumBallPosition.y)
            {
                TrackBall();
                _minimumBallPosition = _ball.transform.position;
            }
        }

        private void TrackBall()
        {
            var beamPosition = _beam.transform.position;
            beamPosition.y = _ball.transform.position.y;
            _cameraPosition = _ball.transform.position;
            Vector3 direction = (beamPosition - _ball.transform.position).normalized + directionOffset;
            _cameraPosition -= direction * lenght;
            transform.position = _cameraPosition;
            transform.LookAt(_ball.transform);
        }
    }
}
