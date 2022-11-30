using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform Enemy1;
    [SerializeField] private Transform SirNugget;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy1, new Vector3(5,0,0),Quaternion.identity);
        Instantiate(SirNugget, new Vector3(-5,0,0),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
