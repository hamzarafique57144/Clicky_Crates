using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    int score;
    public TextMeshProUGUI gameOverTxt;
    public bool isGameActive;
    public Button restartBtn;
    public GameObject titleScreen;
    
    // Start is called before the first frame update
    void Start()
    {
     

        
      //  InvokeRepeating("SpawnTarget",1,1);
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        isGameActive = false;
        restartBtn.gameObject.SetActive(true);
        gameOverTxt.gameObject.SetActive(true);
    }
  
    IEnumerator  SpawnTarget()
    {
        while(isGameActive)
        {
           yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
       
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; 
        scoreTxt.text= score.ToString();
    }
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());

    }
}
