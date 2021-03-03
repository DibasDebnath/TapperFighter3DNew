using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;
   

    public bool playerInSight;
    private Vector3 localPlayerSighting;


    [Header("Line of Sight")]
    [SerializeField] float fovDistance;
    [SerializeField] float fovAngle;
    [SerializeField] float fovHight;
    [SerializeField] Color meshColor = Color.green;

    [Header("Snesor")]
    [SerializeField] private int scanFreq = 30;
    [SerializeField] private LayerMask layers;
    [SerializeField] private LayerMask blockLayers;
    private Collider[] colliders = new Collider[50];
    int count;
    float scanInterval;
    float scanTimer;


    Mesh mesh;

    private void Awake()
    {
        playerInSight = false;
        player = GameObject.Find("Player");
        scanInterval = 1.0f / scanFreq;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scanTimer -= Time.deltaTime;
        if(scanTimer < 0)
        {
            scanTimer += scanInterval;
            Scan();
        }
    }

    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, fovDistance, colliders, layers, QueryTriggerInteraction.Collide);
        if (count == 0)
        {
            //playerInSight = false;
        }
        for (int i = 0; i < count; ++i)
        {
            playerInSight = isInsight(colliders[i].gameObject);
            if (playerInSight)
            {
                localPlayerSighting = player.transform.position;
            }

        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (playerInSight == false)
    //    {
    //        if (other.gameObject == player)
    //        {
    //            playerInSight = true;
    //            localPlayerSighting = player.transform.position;
    //            Debug.Log("AI found Player");
    //        }
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInSight = false;
    //        Debug.Log("AI Lost Player");
    //    }

    //}


    private bool isInsight(GameObject obj)
    {
        
        Vector3 origin = transform.position;
        Vector3 dest = player.transform.position;
        Vector3 direction = dest - origin;


        if(direction.y < 0 || direction.y > fovHight)
        {
            Debug.Log("1");
            return false;
        }

        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);
        if(deltaAngle > fovAngle)
        {
            Debug.Log("2");
            return false;
        }

        origin.y += fovHight / 2;
        dest.y = origin.y;
        if (Physics.Linecast(origin, dest, blockLayers))
        {
            Debug.Log("3");
            return false;
        }

        return true;
            
        
    }



    private Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;

        int numTriangles = ( segments * 4 ) + 2 + 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -fovAngle, 0) * Vector3.forward * fovDistance;
        Vector3 bottomRight = Quaternion.Euler(0, fovAngle, 0) * Vector3.forward * fovDistance;

        Vector3 topCenter = bottomCenter + Vector3.up * fovHight;
        Vector3 topLeft = bottomLeft + Vector3.up * fovHight;
        Vector3 topRight = bottomRight + Vector3.up * fovHight;

        int vert = 0;

        //Left SIde

        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //RIght SIde

        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;


        //Rounded Corners

        float currentAngle = -fovAngle;
        float deltaAngle = (fovAngle * 2) / segments;

        for(int i = 0; i < segments; ++i)
        {
            
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * fovDistance;
            bottomRight = Quaternion.Euler(0, currentAngle + deltaAngle , 0) * Vector3.forward * fovDistance;

            
            topLeft = bottomLeft + Vector3.up * fovHight;
            topRight = bottomRight + Vector3.up * fovHight;


            // Far SIde

            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            //Top

            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            //Bottom

            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;

        }



        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }


    private void OnValidate()
    {
        scanInterval = 1.0f / scanFreq;
        mesh = CreateWedgeMesh();
    }



    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(this.transform.position, distance);

        //Vector3 fovline1 = Quaternion.AngleAxis(angle, this.transform.up) * this.transform.forward * distance;
        //Vector3 fovline2 = Quaternion.AngleAxis(-angle, this.transform.up) * this.transform.forward * distance;

        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(this.transform.position, fovline1);
        //Gizmos.DrawLine(this.transform.position, fovline2);

        if (mesh)
        {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }


        Gizmos.DrawWireSphere(transform.position, fovDistance);
        Gizmos.color = Color.gray;
        for (int i =0; i < count; i++)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.5f);
        }

        Gizmos.color = Color.blue;
        if (playerInSight)
        {
            Gizmos.DrawSphere(player.transform.position, 0.5f);
        }

    }







}
