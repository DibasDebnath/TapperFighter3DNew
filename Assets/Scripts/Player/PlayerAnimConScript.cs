using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimConScript : MonoBehaviour
{
    public PlayerController playerController;

    public Animator animCon;
    private static string HFISTWALK = "hFistWalk";
    private static string VFISTWALK = "vFistWalk";

    private static string SPEED = "Speed";
    private static string PUNCH1 = "Punch1";
    private static string PUNCH2 = "Punch2";
    private static string SUPER1 = "Super1";
    private static string GETHIT1 = "GetHit1";

    private static string IDLE = "Idle";
    private static string RUN = "Run";
    private static string FISTWALK = "FistWalk";
    private static string FISTIDLE = "FistIdle";
    private static string WALK = "Walk";

    List<string> animationNameList = new List<string>();

    void Awake()
    {
        playerController?.onIdle.AddListener(Idle);
        playerController?.onRun.AddListener(Run);
        playerController?.onWalk.AddListener(Walk);
        playerController?.onHit.AddListener(GetHit1);
        playerController?.onAttack.AddListener(Punch);


        animationNameList.Add(IDLE);
        animationNameList.Add(RUN);
        animationNameList.Add(FISTWALK);
        animationNameList.Add(FISTIDLE);
        animationNameList.Add(WALK);

    }

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

    void SetBoolOfAnim(string animName)
    {
        foreach(string str in animationNameList)
        {
            if(string.Equals(str,animName))
            {
                animCon.SetBool(str,true);
            }
            else
            {
                animCon.SetBool(str, false);
            }
        }
    }

    public void Walk(float angle)
    {
        SetBoolOfAnim(FISTWALK);


        //Forward   -45 - 0 - 45
        //Back      -135 - -180 , 135 - 180
        //Left      -45 - -135
        //Right     45 - 135

        if ((angle < 45f && angle > 0f) || (angle > -45f && angle < 0f))
        {
            Debug.Log("Forward");
            animCon.SetFloat(VFISTWALK, 1);
            animCon.SetFloat(HFISTWALK, 0);
        }
        else if ((angle < -135f && angle > -180f) || (angle > 135f && angle < 180f))
        {
            Debug.Log("BackWard");
            animCon.SetFloat(VFISTWALK, -1);
            animCon.SetFloat(HFISTWALK, 0);
        }
        else if(angle > 45f && angle < 135f)
        {
            Debug.Log("Right");
            animCon.SetFloat(VFISTWALK, 0);
            animCon.SetFloat(HFISTWALK, 1);
        }
        else if (angle < -45f && angle > -135f)
        {
            Debug.Log("Left");
            animCon.SetFloat(VFISTWALK, 0);
            animCon.SetFloat(HFISTWALK, -1);
        }
        else
        {
            Debug.Log(angle);
            animCon.SetFloat(VFISTWALK, 0);
            animCon.SetFloat(HFISTWALK, 0);
        }
    }

    public void Run()
    {
        SetBoolOfAnim(RUN);
        
    }

    public void Idle()
    {
        SetBoolOfAnim(IDLE);
        
    }

    public void Punch()
    {
        if(Random.Range(0,2) == 0)
        {
            Punch1();
        }
        else
        {
            Punch2();
        }
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
