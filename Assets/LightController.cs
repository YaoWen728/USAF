using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

    private int Dlightswitch = 1;
    private int Dlightswitch2 = 0;
    public int alightswitch = 0;
    private int alightswitch2 = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("d"))
        {
            if (Dlightswitch == 1 && Dlightswitch2 == 0) {
                Dlightswitch = 0;
                Dlightswitch2 = 1;
                gameObject.GetComponent<Light>().enabled = false;
            }

            if (Dlightswitch == 0 && Dlightswitch2 == 0)
            {
                Dlightswitch = 1;
                Dlightswitch2 = 1;
                gameObject.GetComponent<Light>().enabled = true;
            }

        }

        if (Input.GetKeyDown("a"))
        {
            if (alightswitch == 0 && alightswitch2 == 0)
            {
                alightswitch = 1;
                alightswitch2 = 1;
                gameObject.GetComponent<Light>().color = Color.red;
            }

            if (alightswitch == 1 && alightswitch2 == 0)
            {
                alightswitch = 0;
                alightswitch2 = 1;
                gameObject.GetComponent<Light>().color = Color.white;
            }

        }

        Dlightswitch2 = 0;
        alightswitch2 = 0;
    }
}
