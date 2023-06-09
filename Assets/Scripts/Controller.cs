using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float _speed = 5f;
    private float _verInput;
    private Rigidbody _playerrb;
    private GameObject _focal;
    private bool _hasPower;
    private float _powerStr = 15f;
    private AudioSource _source;

    [SerializeField]
    private GameObject _indicator;
    [SerializeField]
    private GameObject _rounds;
    [SerializeField]
    private GameObject _finish;
    [SerializeField]
    private AudioClip _colis;
    [SerializeField]
    private AudioClip _die;

    void Start()
    {
        _playerrb = GetComponent<Rigidbody>();
        _focal = GameObject.Find("Focal Point");
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        _verInput = Input.GetAxis("Vertical");
        _playerrb.AddForce(_focal.transform.forward * _verInput * _speed);
        _indicator.transform.position = transform.position;//+ new Vector3(0,-0.5f,-0);

        if (transform.position.y < -5)
        {
            _source.PlayOneShot(_die);
        }
        if (transform.position.y < -9)
        {
            Destroy(gameObject);
            _finish.SetActive(true);
            _rounds.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Respawn"))
        {
            Destroy(collider.gameObject);
            _hasPower = true;
            StartCoroutine(LastPower());
            _indicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            _source.PlayOneShot(_colis);
            if (_hasPower)
            {
                Rigidbody enemyrb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = (collision.transform.position - transform.position).normalized;
                enemyrb.AddForce(away * _powerStr, ForceMode.Impulse);
                Debug.Log(_hasPower);
            }
        }
    }

    IEnumerator LastPower()
    {
        yield return new WaitForSeconds(10);
        _hasPower = false;
        _indicator.gameObject.SetActive(false);
    }

}