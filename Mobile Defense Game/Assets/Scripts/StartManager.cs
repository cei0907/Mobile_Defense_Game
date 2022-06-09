using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class StartManager : MonoBehaviour {

    public void gameStart()//사용자가 startButton을 누르면 이 함수가 실행이 된다.
    {
        ShowRewardedAd();//유니티 광고부터 보게 되어있다->수익창출

        SceneManager.LoadScene("GameScene"); //GameScene이라는 Scene이 열리도록
        Time.timeScale = 1;
    }

    public void gameExit()
    {
        Application.Quit();
    }
    
	void Start () {
        Screen.SetResolution(1920, 1200, true); //화면 사이즈 설정
        Advertisement.Initialize("2878145", false);
	}

    private void ShowRewardedAd()
    {
        if(Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }
	
    private void HandleShowResult(ShowResult result)
    {
        switch (result) {
            case ShowResult.Finished:
                Debug.Log("사용자가 광고를 성공적으로 보았습니다.");
                break;
            case ShowResult.Skipped:
                Debug.Log("사용자가 광고가 끝나기 전에 스킵했습니다.");
                break;
            case ShowResult.Failed:
                Debug.Log("광고가 보여지는 과정에서 오류가 발생했습니다.");
                break;
        }
    }

	void Update () {
		
	}
}
