using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
 
    // Start is called before the first frame update
    void Start()
    {
        rowStopped = false;
        timeInterval = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotation()
    {
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        while (!rowStopped)
        {
           if (transform.localPosition.y <= -2f)
                transform.localPosition = new Vector2(transform.localPosition.x, 22f);

            transform.position = new Vector2(transform.position.x, transform.position.y - timeInterval);

            yield return new WaitForSeconds(0.005f);
        }
    }
}
