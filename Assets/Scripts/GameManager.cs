using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Variable for the pillar prefab (Set in editor)
    public GameObject Pillar;
    
    //Variable for the fade gameobject (set in editor)
    public GameObject fade;
    
    public float MaxSpawnY = 3f;
    public float MinSpawnY = -3f;
    public float PillarSpeed = 3;
    
    //Text that shows your score
    public Text ScoreText;
    
    //Text that shows up when you've lost
    public GameObject GameOverText;
    public GameObject RestartButton;
    
    //The players score
    private int _score = 0;

    //Interval between spawning blocks
    private float _spawnTime = 2f;
    
    //A timer to track when to spawn blocks
    private float _time = 0f;

    //Variable to track whether the game is still being played or if the player lost.
    private bool _gameOver = false;
    
    
    
    // Update is called once per frame
    void Update() {
        _time += Time.deltaTime;
        if (_time >= _spawnTime) {
            SpawnPillar();
            _time = 0f;
        }
	
        if(_gameOver && Input.anyKeyDown)
            Restart();

    }



    
    void SpawnPillar() {
        float y = Random.Range(MinSpawnY, MaxSpawnY);
        Vector2 pos = new Vector2(13, y);
        GameObject newPillar = Instantiate(Pillar, pos,  Quaternion.identity) as GameObject;
        newPillar.GetComponent<Wall>().SetSpeed(PillarSpeed);
    }

    
    
    
    public void IncreaseScore() {
        _score++;
        ScoreText.text = _score.ToString();
    }

    
    

    public void GameOver() {
        fade.SetActive(true);
        GameOverText.SetActive(true);
        RestartButton.SetActive(true);
        _gameOver = true;
    }


    public void Restart() {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
