using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

    void Awake()
    {
        GameManager.getInstance().initialize();
    }
}
