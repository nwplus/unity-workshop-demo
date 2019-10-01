using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private Rigidbody2D _rigid;
    
    // Start is called before the first frame update
    void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
    }


    void Update() {
        if (transform.position.x <= -15f) {
            Destroy(this.gameObject);
        }
    }


    public void SetSpeed(float speed) {
        _rigid.velocity = new Vector2(-1f * speed, 0f);
    }
}
