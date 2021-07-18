using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public AdsManager adsManager;
    public Text score;
    
    public SaveData saveData;
    
    [SerializeField]
    private float baseSpeed = 10f;
    [SerializeField]
    private float upDownSpeed = 15.0f;
    private Rigidbody _rb;
    private Vector3 _movement;
    private Boolean _stop = false;
    private int _score = 0;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movement = new Vector3(baseSpeed, 0, 0);
        StartCoroutine(UpdateScore());
    }

    void Update()
    {
        if (Input.touchCount > 0 && !_stop)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _movement = new Vector3(baseSpeed, upDownSpeed * -1, 0);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _movement = new Vector3(baseSpeed, upDownSpeed, 0);
            }
        }

        if (!_stop)
        {
            _rb.velocity = _movement;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _movement = new Vector3(baseSpeed, 0, 0);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _stop = true;
            saveData.SaveFile(_score);
            adsManager.CloseBannerAd();
            SceneManager.LoadScene("GameOver");
        }
        
    }

    private IEnumerator UpdateScore()
    {
        if (!_stop)
        {
            _score += 1;
            score.text = _score.ToString();

            if (_score == 5)
            {
                adsManager.PlayBannerAd();
            }
        }
        yield return new WaitForSeconds(1);
        
        yield return UpdateScore();
    }
}