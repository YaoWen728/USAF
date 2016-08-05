using UnityEngine;
using System.Collections;

public class SpotlightController : MonoBehaviour {
    private int Slightswitch = 0;
    private int Slightswitch2 = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("s"))
        {
            if (Slightswitch == 1 && Slightswitch2 == 0)
            {
                Slightswitch = 0;
                Slightswitch2 = 1;
                gameObject.GetComponent<Light>().enabled = false;
            }

            if (Slightswitch == 0 && Slightswitch2 == 0)
            {
                Slightswitch = 1;
                Slightswitch2 = 1;
                gameObject.GetComponent<Light>().enabled = true;
            }

        }

        Slightswitch2 = 0;
    }
}
