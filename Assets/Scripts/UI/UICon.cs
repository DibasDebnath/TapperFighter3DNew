using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UICon : MonoBehaviour
{
    public UIAnimCon animCon;

    public bool takeInput;


    [Header("MainPanel")]
    public Button playBut;
    

    [Header("GamePanel")]
    public TextMeshProUGUI playerText;
   


    [Header("EndPanel")]
    public Button playButEnd;
    




    // Start is called before the first frame update
    void Start()
    {
        //playBut.onClick.AddListener(() => PlayButPress());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    #region Main Menu

    private void PlayButPress()
    {

    }







    #endregion
}
