using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Pillar;
    public GameObject Fade;

    public float MaxSpawnY;
    public float MinSpawnY;
    public float PillarSpeed;
    public float PillarSpawnTime;
    
    public Text ScoreText;
    
    public GameObject GameOverText;
    public GameObject RestartButton;

    private int _score;
    private float _time;
    


    // Update is called once per frame
    void Update() {
        _time += Time.deltaTime;
        if (_time >= PillarSpawnTime) {
            SpawnPillar();
            _time = 0f;
        }
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
        Fade.SetActive(true);
        GameOverText.SetActive(true);
        RestartButton.SetActive(true);
    }



    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
