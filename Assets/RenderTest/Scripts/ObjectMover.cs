using UnityEngine;

namespace RenderTest
{
    public class ObjectMover : MonoBehaviour
    {
        private Vector3 _initialPosition;
        private float _timeRandomMultiplier = 0f;

        private void Start()
        {
            _initialPosition = transform.position;
            _timeRandomMultiplier = Random.Range(1f, 10f);
        }

        private void Update()
        {
            transform.position = _initialPosition + Vector3.right * Mathf.Sin(Time.time * _timeRandomMultiplier);
        }
    }
}
