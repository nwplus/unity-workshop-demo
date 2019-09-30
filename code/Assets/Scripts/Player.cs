using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour {

    public GameManager gameManager;
    
    public Vector2 Force =  new Vector2(0, 6);

    private Rigidbody2D _rigid;

    private bool _jump = false;
    private float _minY;
    private float _maxY;
    
    // Start is called before the first frame update
    void Awake() {
        _rigid = GetComponent<Rigidbody2D>();

        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);

        _maxY = topRight.y;
        _minY = bottomLeft.y;
    }

    
    
    // Update is called once per frame
    void Update() {
        if (transform.position.y < _minY || transform.position.y > _maxY)
            GameOver();
        
        if (Input.GetKeyDown(KeyCode.Space))
            _jump = true;
    }

    
    
    void FixedUpdate() {
        if (_jump) {
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Force, ForceMode2D.Impulse);
            _jump = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        gameManager.IncreaseScore();
    }


    private void OnCollisionEnter2D(Collision2D other) {
        GameOver();
    }

    
    
    void GameOver() {
        gameManager.GameOver();
        Destroy(gameObject);
    }
}
