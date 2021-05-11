using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stage;       //현재 단계
    public int stagePoint;  //모은 재료수
    public string[] types 
        = new string[] { 
            "<color=#cc0000>Selineae\n불</color>", 
            "<color=#0033cc>Neru\n물</color>", 
            "<color=#999999>Pete\n바위</color>", 
            "<color=#99ccff>Aeris\n바람</color>"}; //속성 배열

    public GameObject VictoryPanel;//승리 화면

    public GameObject B1_1; //모을 재료 표시
    public GameObject B1_2;
    public GameObject B1_3;
    public GameObject B2_1;
    public GameObject B2_2;
    public GameObject B3_1;
    public GameObject B3_2;
    public GameObject B4_1;
    public GameObject B4_2;
    public GameObject B4_3;
    public GameObject B4_4;


    public GameObject M1;  //만들어진 아이템 표시
    public GameObject M2;
    public GameObject M3;
    public GameObject M4;

    public GameObject Blind1;   //가림막
    public GameObject Blind2;
    public GameObject Blind3;


    void Start()    //초기 세팅
    {
        Text T1_1 = B1_1.GetComponentInChildren<Text>();    //버튼 텍스트 변수
        Text T1_2 = B1_2.GetComponentInChildren<Text>();
        Text T1_3 = B1_3.GetComponentInChildren<Text>();

        //승리 패널 비활성화
        VictoryPanel.SetActive(false);

        //2단계 이상 비활성화
        B2_1.SetActive(false);
        B2_2.SetActive(false);
        B3_1.SetActive(false);
        B3_2.SetActive(false);
        B4_1.SetActive(false);
        B4_2.SetActive(false);
        B4_3.SetActive(false);
        B4_4.SetActive(false);

        M1.SetActive(false);
        M2.SetActive(false);
        M3.SetActive(false);

        //1단계 랜덤 생성
        T1_1.text = Randomtype();
        T1_2.text = Randomtype();
        T1_3.text = Randomtype();

    }

    public void NextStage() //다음 단계 함수
    {  //버튼 텍스트 변수
        Text T2_1 = B2_1.GetComponentInChildren<Text>();
        Text T2_2 = B2_2.GetComponentInChildren<Text>();

        Text T3_1 = B3_1.GetComponentInChildren<Text>();
        Text T3_2 = B3_2.GetComponentInChildren<Text>();

        Text T4_1 = B4_1.GetComponentInChildren<Text>();
        Text T4_2 = B4_2.GetComponentInChildren<Text>();
        Text T4_3 = B4_3.GetComponentInChildren<Text>();
        Text T4_4 = B4_4.GetComponentInChildren<Text>();

        switch (stage)  //단계별 행동
        {
            case 1: //1단계 완수
                T2_1.text = Randomtype();
                T2_2.text = Randomtype();

                Blind1.SetActive(false);
                M1.SetActive(true);
                B2_1.SetActive(true);
                B2_2.SetActive(true);
                break;

            case 2: //2단계 완수
                T3_1.text = Randomtype();
                T3_2.text = Randomtype();

                Blind2.SetActive(false);
                M2.SetActive(true);
                B3_1.SetActive(true);
                B3_2.SetActive(true);
                break;

            case 3: //3단계 완수
                T4_1.text = Randomtype();
                T4_2.text = Randomtype();
                T4_3.text = Randomtype();
                T4_4.text = Randomtype();

                Blind3.SetActive(false);
                M3.SetActive(true);
                B4_1.SetActive(true);
                B4_2.SetActive(true);
                B4_3.SetActive(true);
                B4_4.SetActive(true);
                break;

            case 4: //4단계 완수, 승리
                M4.SetActive(false);
                Invoke("Victory", 2f);
                break;
        }

        stage++;
    }

    public void Victory()
    {
        VictoryPanel.SetActive(true);
    }

    public void Point(GameObject Btn)   //재료 모음
    {
        Image Btnimg = Btn.GetComponent<Image>();
        Btn.GetComponent<Button>().interactable = false;
        stagePoint++;

        if (stagePoint == 3) //재료 모을 경우
        {
            if(stage < 3)//3단계 까지
            {
                stagePoint = 1;
            }
            else//마지막 단계
            {
                stagePoint = -1;
            }
            NextStage();
        }
    }

    public string Randomtype()  //속성 스트링 랜덤 반환
    {
        int rand = Random.Range(0, 4);
        string type = types[rand];
        return type;
    }

    public void Restart()   //재시작
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()  //게임 종료
    {
        Application.Quit(); 
    }
}