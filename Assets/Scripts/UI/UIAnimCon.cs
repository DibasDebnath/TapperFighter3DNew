using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimCon : MonoBehaviour
{


    public Animator mainMenu;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region Main Menu

    public void MainMenuIn()
    {
        mainMenu.SetTrigger("MenuIn");
    }
    public void MainMenuOut()
    {
        mainMenu.SetTrigger("MenuOut");
    }


    #endregion


}
