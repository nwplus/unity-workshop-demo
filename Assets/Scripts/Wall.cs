using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private Rigidbody2D _rigid;
    
    void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (transform.position.x <= -15f)
            Destroy(gameObject);
    }


    public void SetSpeed(float speed) {
        _rigid.velocity = new Vector2(-1f * speed, 0f);
    }
}
