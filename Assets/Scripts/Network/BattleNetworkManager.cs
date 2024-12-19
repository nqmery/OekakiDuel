using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleNetworkManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        byte signalType = NetworkManager.networkManager.GetMessage()[0];

    }
}
