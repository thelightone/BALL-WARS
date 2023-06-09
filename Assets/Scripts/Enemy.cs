using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 3f;
    private GameObject _player;
    private Rigidbody _rb;
    private AudioSource _source;

    [SerializeField]
    private AudioClip _die;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * _speed);
        if (transform.position.y < -9)
            Destroy(gameObject); _source.PlayOneShot(_die);
    }
}
