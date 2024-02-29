using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDMonsterGenerator : MonoBehaviour
{
    private static TDMonsterGenerator _instance;
    public static TDMonsterGenerator Instance { get { return _instance; } }
    public TDMonster[] MonList;


    private void Start()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    public void Generate()
    {
        int i = Random.Range(0, MonList.Length);
        Instantiate(MonList[i].gameObject, MonList[i].transform.position, MonList[i].transform.rotation);
    }


}
