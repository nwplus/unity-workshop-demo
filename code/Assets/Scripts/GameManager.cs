using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    
    public GameObject pillar;
    public GameObject fade;
    
    public float MaxY = 3f;
    public float MinY = -3f;
    public float PillarSpeed = 3;
    
    public Text ScoreText;
    
    public GameObject GameOverText;
    public GameObject RestartButton;
    
    private int _score = 0;
    private float _spawnTime = 2f;
    private float _time = 0f;
    
    
    void Update() {
        _time += Time.deltaTime;
        if (_time >= _spawnTime) {
            SpawnPillar();
            _time = 0f;
        }
    }


    void SpawnPillar() {

        float y = Random.Range(MinY, MaxY);
        Vector2 pos = new Vector2(13, y);
        GameObject newPillar = Instantiate(pillar, pos, Quaternion.identity) as GameObject;
        newPillar.GetComponent<Wall>().SetSpeed(PillarSpeed);
    }
    
    
    
    
    public void IncreaseScore() {
        _score += 1;
        ScoreText.text = _score.ToString();
    }

    

    public void GameOver() {
        fade.SetActive(true);
        GameOverText.SetActive(true);
        RestartButton.SetActive(true);
    }


    public void Restart() {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
