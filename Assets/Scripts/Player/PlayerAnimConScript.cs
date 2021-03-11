using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimConScript : MonoBehaviour
{

    public Animator animCon;



    private static string Horizontal = "Horizontal";
    private static string Vertical = "Vertical";
    private static string SPEED = "Speed";
    private static string PUNCH1 = "Punch1";
    private static string PUNCH2 = "Punch2";
    private static string SUPER1 = "Super1";
    private static string GETHIT1 = "GetHit1";
    private static string IDLE = "Idle";
    private static string RUN = "Run";
    private static string FISTWALK = "FistWalk";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerMovement(float v, float h)
    {
        
        //animCon.SetFloat(Vertical, v);
        //animCon.SetFloat(Horizontal, h);
        //animCon.SetFloat(Speed, Mathf.Abs(v)+Mathf.Abs(h));
    }

    public void Walk()
    {
        animCon.SetBool(FISTWALK, true);
        animCon.SetBool(RUN, false);
        animCon.SetBool(IDLE, false);
    }

    public void Run()
    {
        animCon.SetBool(RUN, true);
        animCon.SetBool(IDLE, false);
        animCon.SetBool(FISTWALK, false);
    }

    public void Idle()
    {
        animCon.SetBool(IDLE, true);
        animCon.SetBool(FISTWALK, false);
        animCon.SetBool(RUN, false);
    }

    public void Punch1()
    {
        PlayAnimation(PUNCH1);
    }

    public void Punch2()
    {
        PlayAnimation(PUNCH2);
    }

    public void Super1()
    {
        PlayAnimation(SUPER1);
    }

    public void GetHit1()
    {
        PlayAnimation(GETHIT1);
    }


    public void PlayAnimation(string name)
    {
        animCon.SetTrigger(name);
    }
    
}
