using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    //총알의 행동을 정의하는 script

    public BulletStat bulletStat { get; set; }
    public GameObject character;

    public BulletBehavior()
    {
        bulletStat = new BulletStat(0, 0);
        //BulletBehavior가 초기화가 될 때 BulletStat도 초기화 되도록
    }



	void Start () {
        Destroy(gameObject, 3.0f);
	}
	
	void Update () {
        transform.Translate(Vector2.right * bulletStat.speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            other.GetComponent<MonsterStat>().attacked(bulletStat.damage);
            //other의 컴포넌트<MonsterStat>을 가져와서 그 안에 attacked함수를 실행시켜라 이런 의미인듯
        }   
    }
}
