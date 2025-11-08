using UnityEngine;

/// <summary>
/// ÉJÉÅÉâÇÃí≤êﬂ
/// </summary>
public class CameraAdjustment : MonoBehaviour
{
    [SerializeField] private Transform chaseTarget;
    [SerializeField] private float smoothSpeedY = 0.1f;
    [SerializeField] private Vector3 offset;

    private float targetY;

    private void LateUpdate()
    {
        if(chaseTarget != null)
        {
            float _targetX = chaseTarget.position.x + offset.x;

            targetY = Mathf.Lerp(transform.position.y, chaseTarget.position.y + offset.y, smoothSpeedY);

            float _targetZ = offset.z;

            transform.position = new Vector3(_targetX, targetY, _targetZ);
        }
    }
}
