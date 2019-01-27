using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public int PosButton;
    public int MaxButtons;

    public int Vertice;
    public int Gambiarra;
    // Start is called before the first frame update
    void Start()
    {
        PosButton = 0;
        //this.gameObject.transform.position =new Vector3 (-110.3f,-25.4f,0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (PosButton)
        {
            // case 0: this.gameObject.transform.position =new Vector3 (-110.3f,-25.4f,0); //JOGAR
            // break;
            
            // case 1: this.gameObject.transform.position =new Vector3 (-110.3f,-67.3f,0); //BONUS
            // break;

            // case 2: this.gameObject.transform.position =new Vector3 (-110.3f,-106.8f,0);//CONTROLE
            // break;

            // case 3: this.gameObject.transform.position =new Vector3 (-110.3f,-148.7f,0);//CRÉDITOS
            // break;

            // case 4: this.gameObject.transform.position =new Vector3 (-110.3f,-25.4f,0);//SAIR
            // break;
        }

       if (Input.GetAxisRaw("Vertical") >=1)
       {
           PosButton++;
       }
        


        
    }
}
