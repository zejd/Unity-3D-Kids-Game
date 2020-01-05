using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AnimalGameMnagaer : MonoBehaviour {

    public GameObject bear, panda, deer, fox, teddyBear, bearBlack, pandaBlack, deerBlack, foxBlack, teddyBearBlack;
    
    public GameObject winText, playAgain;

    public Button replay, exit;
    public Text numOfCorrectAnswers, scoreOverall;
    Vector3 bearInitialPos, pandaInitialPos, deerInitialPos, foxInitialPos, teddyBearInitialPos,
            bearBlackInitialPos, pandaBlackInitialPos, deerBlackInitialPos, foxBlackInitialPos, teddyBearBlackInitialPos;

    Vector3[] positions = new Vector3[5];
    Vector3[] positionsOfShadows = new Vector3[5];

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;
    public AudioClip win;

    private int correctAnswers = 0, score = 0;


    void Start() {
        bearInitialPos = bear.transform.position;
        pandaInitialPos = panda.transform.position;
        deerInitialPos = deer.transform.position;
        foxInitialPos = fox.transform.position;
        teddyBearInitialPos = teddyBear.transform.position;

        bearBlackInitialPos = bearBlack.transform.position;
        pandaBlackInitialPos = pandaBlack.transform.position;
        deerBlackInitialPos = deerBlack.transform.position;
        foxBlackInitialPos = foxBlack.transform.position;
        teddyBearBlackInitialPos = teddyBearBlack.transform.position;

        positions[0] = bearInitialPos;
        positions[1] = pandaInitialPos;
        positions[2] = deerInitialPos;
        positions[3] = foxInitialPos;
        positions[4] = teddyBearInitialPos;

        positionsOfShadows[0] = bearBlackInitialPos;
        positionsOfShadows[1] = pandaBlackInitialPos;
        positionsOfShadows[2] = deerBlackInitialPos;
        positionsOfShadows[3] = foxBlackInitialPos;
        positionsOfShadows[4] = teddyBearBlackInitialPos;

        replay = GameObject.FindGameObjectWithTag("play").GetComponent<Button>();
        numOfCorrectAnswers = GameObject.FindGameObjectWithTag("correctansw").GetComponent<Text>();
        scoreOverall = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        scoreOverall.color = Color.gray;
        playAgain.SetActive(false);
        winText.SetActive(false);
	    replay.onClick.AddListener(PlayAgain); 
        exit.onClick.AddListener(ExitGame);     
    }
    
    public void DragBear() {
        bear.transform.position = Input.mousePosition;
    }
    
    public void DragPanda() {
        panda.transform.position = Input.mousePosition;
    }

    public void DragDeer() {
        deer.transform.position = Input.mousePosition;
    }

    public void DragFox() {
        fox.transform.position = Input.mousePosition;
    }

    public void DragTeddyBear() {
        teddyBear.transform.position = Input.mousePosition;
    }

    public void DropBear() {
        float distance = Vector3.Distance(bear.transform.position, bearBlack.transform.position);
        if(distance < 50) {
            bear.transform.position = bearBlack.transform.position;
            source.clip = correct[UnityEngine.Random.Range(0, correct.Length)];
            source.Play();
            correctAnswers++;
            score++;
            numOfCorrectAnswers.text = correctAnswers.ToString();
            CheckScore();
            scoreOverall.text = score.ToString();
            CheckWin();
        } else {
            bear.transform.position = bearInitialPos;
            source.clip = incorrect;
            score--;
            CheckScore();
            scoreOverall.text = score.ToString();
            source.Play();
        }
    }

    public void DropPanda() {
        float distance = Vector3.Distance(panda.transform.position, pandaBlack.transform.position);
        if(distance < 50) {
            panda.transform.position = pandaBlack.transform.position;
            source.clip = correct[UnityEngine.Random.Range(0, correct.Length)];
            source.Play();
            correctAnswers++;
            score++;
            numOfCorrectAnswers.text = correctAnswers.ToString();
            CheckScore();
            scoreOverall.text = score.ToString();
            CheckWin();
        } else {
            panda.transform.position = pandaInitialPos;
            source.clip = incorrect;
            score--;
            CheckScore();
            scoreOverall.text = score.ToString();
            source.Play();
        }
    }

    public void DropDeer() {
        float distance = Vector3.Distance(deer.transform.position, deerBlack.transform.position);
        if(distance < 50) {
            deer.transform.position = deerBlack.transform.position;
            source.clip = correct[UnityEngine.Random.Range(0, correct.Length)];
            source.Play();
            correctAnswers++;
            score++;
            numOfCorrectAnswers.text = correctAnswers.ToString();
            CheckScore();
            scoreOverall.text = score.ToString();
            CheckWin();
        } else {
            deer.transform.position = deerInitialPos;
            source.clip = incorrect;
            score--;
            CheckScore();
            scoreOverall.text = score.ToString();
            source.Play();
        }
    }

    public void DropFox() {
        float distance = Vector3.Distance(fox.transform.position, foxBlack.transform.position);
        if(distance < 50) {
            fox.transform.position = foxBlack.transform.position;
            source.clip = correct[UnityEngine.Random.Range(0, correct.Length)];
            source.Play();
            correctAnswers++;
            score++;
            numOfCorrectAnswers.text = correctAnswers.ToString();
            CheckScore();
            scoreOverall.text = score.ToString();
            CheckWin();
        } else {
            fox.transform.position = foxInitialPos;
            source.clip = incorrect;
            score--;
            CheckScore();
            scoreOverall.text = score.ToString();
            source.Play();
        }
    }

    public void DropTeddyBear() {
        float distance = Vector3.Distance(teddyBear.transform.position, teddyBearBlack.transform.position);
        if(distance < 50) {
            teddyBear.transform.position = teddyBearBlack.transform.position;
            source.clip = correct[UnityEngine.Random.Range(0, correct.Length)];
            source.Play();
            correctAnswers++;
            score++;
            numOfCorrectAnswers.text = correctAnswers.ToString();
            CheckScore();
            scoreOverall.text = score.ToString();
            CheckWin();
        } else {
            teddyBear.transform.position = teddyBearInitialPos;
            source.clip = incorrect;
            score--;
            CheckScore();
            scoreOverall.text = score.ToString();
            source.Play();
        }
    }

    public void PlayAgain() {
        RandomizePositions();
        correctAnswers = 0;
        numOfCorrectAnswers.text = correctAnswers.ToString();
        playAgain.SetActive(false);
        winText.SetActive(false);
    }

    public void CheckWin() {
        if (correctAnswers == 5) {
            playAgain.SetActive(true);
            winText.SetActive(true);
            source.clip = win;
            source.Play();
        }
    }

    public void RandomizePositions() {
        System.Random rnd = new System.Random();
        List<int> randomPositions = new List<int>();
        int count = 100;
        for(int i=0;i<5;i++) {
            while(count > 0) {
                count--;
                if(randomPositions.Count == 5) {
                    break;
                }
                int pos = UnityEngine.Random.Range(0, positions.Length);  
                if(!randomPositions.Exists(position => position == pos)){
                    randomPositions.Add(pos);
                    break;
                }
            }  
        }
        bear.transform.position = bearInitialPos = positions[randomPositions[0]];
        panda.transform.position = pandaInitialPos = positions[randomPositions[1]];
        deer.transform.position = deerInitialPos = positions[randomPositions[2]];
        fox.transform.position = foxInitialPos = positions[randomPositions[3]];
        teddyBear.transform.position = teddyBearInitialPos = positions[randomPositions[4]];

        bearBlack.transform.position = positionsOfShadows[randomPositions[1]];
        pandaBlack.transform.position = positionsOfShadows[randomPositions[2]];
        deerBlack.transform.position = positionsOfShadows[randomPositions[4]];
        foxBlack.transform.position = positionsOfShadows[randomPositions[0]];
        teddyBearBlack.transform.position = positionsOfShadows[randomPositions[3]];
    }

    public void CheckScore() {
        if(score == 0) {
            scoreOverall.color = Color.gray;
        } else if(score > 0) {
            scoreOverall.color = Color.green;
        } else if(score < 0) {
            scoreOverall.color = Color.red;
        }
    }

    void ExitGame(){
        SceneManager.LoadScene(1);
    }
}
