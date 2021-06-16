using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{

    public Reel[] reel;

    bool startSpin;

    // Start is called before the first frame update
    void Start()
    {
        startSpin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startSpin)
        {  
            if (Input.GetKeyDown(KeyCode.K))
            {
                startSpin = true;
                StartCoroutine(Spinning());
            }
        }
    }

    void calculateResults(HashSet<string> finalResult)
    {
        if (finalResult.Count == 1)
        {
            Debug.Log("+100 Points!");
        }
        else
            Debug.Log("No Winner");
    }

    IEnumerator Spinning()
    {
        HashSet<string> finalResult = new HashSet<string>();
        foreach (Reel spinner in reel)
        {
            spinner.spin = true;
        }
        for (int i = 0; i < reel.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(1,3));
            reel[i].spin = false;
            reel[i].RandomPosition();
            finalResult.Add(reel[i].result);
        }
        startSpin = false;
        calculateResults(finalResult);
    }
}
