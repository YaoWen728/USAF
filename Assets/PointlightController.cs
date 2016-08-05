using UnityEngine;
using System.Collections;

public class PointlightController : MonoBehaviour {
    private int Plightswitch = 0;
    private int Plightswitch2 = 0;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("p"))
        {
            if (Plightswitch == 1 && Plightswitch2 == 0)
            {
                Plightswitch = 0;
                Plightswitch2 = 1;
                gameObject.GetComponent<Light>().enabled = false;
            }

            if (Plightswitch == 0 && Plightswitch2 == 0)
            {
                Plightswitch = 1;
                Plightswitch2 = 1;
                gameObject.GetComponent<Light>().enabled = true;
            }

        }

        Plightswitch2 = 0;


    }
}
