using UnityEngine;

public class Player : MonoBehaviour {
    
    //The amount of force to apply when the jump button is pressed
    public Vector2 Force = new Vector2(0, 5);

    //Variable to hold the physics component of the player
    private Rigidbody2D _rigid;

    //Boolean letting us know whether the jump button was pressed
    private bool _jump = false;

    //The max and min height the player is allowed to go to
    private float _minY;
    private float _maxY;
    
    
    // Start is called before the first frame update
    void Awake() {

    }

    // Update is called once per frame
    void Update() {
    }

    //Fixed update is called at set intervals every x seconds
    void FixedUpdate()
    {

    }


    private void OnTriggerEnter2D(Collider2D other) {
    }

    
    
    private void OnCollisionEnter2D(Collision2D other) {
    }



    void GameOver() {
        Destroy(gameObject);
        GameManager.GameOver();
    }
}
