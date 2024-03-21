using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBuildingSite : MonoBehaviour
{
    
    [SerializeField]
    private bool canBuild = false;
    public bool CanBuild { get { return canBuild; } set { canBuild = value; } }

    [SerializeField]
    private MeshRenderer[] modelRdr;
    [SerializeField]
    private MeshRenderer planeRdr;
    // Start is called before the first frame update
    void Start()
    {
        //Setup Building Color
        for (int i = 0; i < modelRdr.Length; i++)
            modelRdr[i].material.color = Color.green;     
        
        //Setup Plane Color
        planeRdr.material.color = Color.green;
        
        CanBuild = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void SetCanBuild(bool flag)
    {
        if (flag)
        {
            Color color = Color.green;
            color.a = 0.3f;
            for (int i = 0; i < modelRdr.Length; i++)
                modelRdr[i].material.color = color;
            
            planeRdr.material.color = color;
            canBuild = true;
        }
        else
        {
            Color color = Color.red;
            color.a = 0.3f;
            for (int i = 0; i < modelRdr.Length; i++)
                modelRdr[i].material.color = color;
            
            planeRdr.material.color = color;
            canBuild = false;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == "Resource" || other.tag == "Building" || other.tag == "Unit")
            SetCanBuild(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Resource" || other.tag == "Building" || other.tag == "Unit")
            SetCanBuild(false);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Resource" || other.tag == "Building" || other.tag == "Unit")
            SetCanBuild(true);
    }
}
