using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float _rotSpeed = 100f;
    private float _hotInput;

    void Update()
    {
        _hotInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, _hotInput * Time.deltaTime * _rotSpeed);
    }
}
