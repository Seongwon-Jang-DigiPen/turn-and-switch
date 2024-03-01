using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject MonPrefab;

    public float GenerateTime = 1;
    float _timer = 0;
    private void Update()
    {
        if (GenerateTime < _timer)
        {
            _timer = 0;
            Generate();
        }
        _timer += Time.deltaTime;
    }

    void Generate()
    {
        Instantiate(MonPrefab, Def.GetDirection(Random.Range(0, 360), Random.Range(6f, 10f)), MonPrefab.transform.rotation).GetComponent<EnemyBase>().Speed = Random.Range(1f, 4f);
    }
}
