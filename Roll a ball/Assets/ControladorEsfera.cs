using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEsfera : MonoBehaviour
{
    public float speed;    
    private int count;
    public Text text;
    public Text wintext;


    void Start ()
    {
        count = 0;
        updateCounter();
        wintext.text = " ";
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        GetComponent<Rigidbody>().AddForce(direction * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        Destroy(other.gameObject);
        count++;
        updateCounter();
    }

    void updateCounter(){
        text.text = "Puntos: " + count;
        int numPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        if(numPickups == 1){
            wintext.text = "Has Ganado!";
        }
    }
}