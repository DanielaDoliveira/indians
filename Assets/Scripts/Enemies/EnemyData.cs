using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data",menuName = "Enemies/Enemies Data")]
public class EnemyData : ScriptableObject
{
  
    public string enemyName;
    public GameObject prefab;
    public float speed;
    public EnemyType type;
    

}

public enum EnemyType
{
    Wolf,
    Bear,
    Arrow
}