using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour {

    //private GameManager GameManager.instance;

    public List<GameObject> respawnSpotList;

    //public GameObject respawnSpot1;
    //public GameObject respawnSpot2;
    //public GameObject respawnSpot3;
    //public GameObject respawnSpot4;

    public GameObject monster1Prefab;
    public GameObject monster2Prefab;

    private GameObject monsterPrefab;

    private float lastSpawnTime;
    private int spawnCount = 0;

    void Start () {
        //gameManager= GameObject.Find("Game Manager").GetComponent<GameManager>();
        //gameManager = new GameManager();//유니티라는 엔진에서는 클레스의 instance화가 start()함수보다 먼저 실행된다. 그렇기 때문에 start함수에서 초기화되어야 할 값들이 초기화되기전에 그 값들을 이용해서 instance가 생성되면 문제가 발생할수 있다ㅓ.
        monsterPrefab = monster1Prefab;
        lastSpawnTime = Time.time;
	}
	
	void Update () {
		if(GameManager.instance.round <= GameManager.instance.totalRound)
        {
            float timeGap = Time.time - lastSpawnTime;
            if(((spawnCount == 0 && timeGap > GameManager.instance.roundReadyTime) // 새 라운드가 시작
                || timeGap > GameManager.instance.spawnTime)
                && spawnCount < GameManager.instance.spawnNumber)
            {
                lastSpawnTime = Time.time;
                int index = Random.Range(0, 4);
                GameObject respawnSpot = respawnSpotList[index];
                //if(respawnSpotNumber == 1)
                //{
                //    respawnSpot = respawnSpot1;
                //}
                //if (respawnSpotNumber == 2)
                //{
                //    respawnSpot = respawnSpot2;
                //}
                //if (respawnSpotNumber == 3)
                //{
                //    respawnSpot = respawnSpot3;
                //}
                //if (respawnSpotNumber == 4)
                //{
                //    respawnSpot = respawnSpot4;
                //}
                Instantiate(monsterPrefab, respawnSpot.transform.position, Quaternion.identity);
                spawnCount += 1;
            }
            if(spawnCount == GameManager.instance.spawnNumber &&
               GameObject.FindGameObjectWithTag("Monster") == null)
            {
                if(GameManager.instance.totalRound == GameManager.instance.round)
                {
                    GameManager.instance.gameClear();
                    GameManager.instance.round += 1;
                    return;
                }
                GameManager.instance.clearRound();
                spawnCount = 0;
                lastSpawnTime = Time.time;

                if(GameManager.instance.round == 4)
                {
                    monsterPrefab = monster2Prefab;
                    GameManager.instance.spawnTime = 2.0f;
                    GameManager.instance.spawnNumber = 10;
                }
            }
        }
	}
}
