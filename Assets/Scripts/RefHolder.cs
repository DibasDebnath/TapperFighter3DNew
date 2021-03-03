using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefHolder : MonoBehaviour
{
    public static RefHolder instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public GamePlay gamePlay;
    public InputController inputController;
    public UICon uICon;
    public AudioController audioController;
    public PlayerController playerController;
}
