using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//VO : Value Object :데이터의 속성 명시
public class BulletStat 
{
    public float speed { get; set; }
    public int damage { get; set; }

    public BulletStat(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }
    // Start is called before the first frame update
}
