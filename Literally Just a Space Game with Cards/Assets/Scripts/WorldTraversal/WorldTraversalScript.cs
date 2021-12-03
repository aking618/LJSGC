using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTraversalScript : MonoBehaviour
{

    public Planet[] planets;

    // Start is called before the first frame update
    void Start()
    {
        // spawn a line in between the planets
        for (int i = 0; i < planets.Length; i++)
        {
            if (i == 0)
            {
                continue;
            }
            else
            {
                LineRenderer line = new GameObject().AddComponent<LineRenderer>();
                line.startWidth = 5f;
                line.endWidth = 5f;
                line.startColor = Color.white;
                line.endColor = Color.white;
                line.positionCount = 2;
                line.SetPosition(0, planets[i - 1].transform.position);
                line.SetPosition(1, planets[i].transform.position);

                // change sorting layer of line renderer
                line.sortingOrder = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
