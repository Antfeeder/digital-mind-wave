using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{

    public bool spin;

    public string result;

    int speed;


    // Start is called before the first frame update
    void Start()
    {
        spin = false;
        speed = 1500;
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            foreach (Transform image in transform)
            {
                image.transform.Translate(Vector3.down * Time.smoothDeltaTime * speed, Space.World);
                if (image.transform.position.y <= 0) {image.transform.position = new Vector3(image.transform.position.x, image.transform.position.y + 600, image.transform.position.z);}

            }
        }
    }

    public void RandomPosition()
    {
        List<int> parts = new List<int>();

        parts.Add(0);
        parts.Add(-125);
        parts.Add(-250);
        parts.Add(-375);
        parts.Add(-500);
        parts.Add(-625);
        parts.Add(-750);

        foreach (Transform image in transform)
        {
            int rand = Random.Range(0,parts.Count);

            image.transform.position = new Vector3(image.transform.position.x, parts[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y, image.transform.position.z);

            if (parts[rand] == 0)
            {
                result = image.tag;
            }

            parts.RemoveAt(rand);
        }
    }
}
