using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public GameManager GameManager;

    public Vector2 Force = new Vector2(0, 5);
    private Rigidbody2D _rigid;

    private bool _jump = false;
    private float _minY;
    private float _maxY;
    
    
    // Start is called before the first frame update
    void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
        
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        _minY = bottomLeft.y;
        _maxY = topRight.y;
    }

    void Update() {
        if (transform.position.y < _minY)
            GameOver();
        if (transform.position.y > _maxY)
            GameOver();
        
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
            _jump = true;
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_jump) {
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Force, ForceMode2D.Impulse);
            _jump = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.isTrigger) 
            GameManager.IncreaseScore();
    }

    
    
    private void OnCollisionEnter2D(Collision2D other) {
        GameOver();
    }



    void GameOver() {
        Destroy(gameObject);
        GameManager.GameOver();
    }
}
