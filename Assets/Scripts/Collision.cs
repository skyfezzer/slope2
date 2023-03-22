using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    public GameObject map;
    private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag =="enemy"){
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "cp"){
            map = Instantiate(map);
            map.transform.position += new Vector3(0f,-52f,87f);
        }
        if(other.gameObject.tag =="boostramp"){
            controller.BoostUp();
        }
    }
}
