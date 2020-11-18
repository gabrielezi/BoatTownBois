using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Gathering : MonoBehaviour
{
    public Slider slider;
    public GameObject canvas;
    public GameObject tree;
    int k = 0;

    private void Start()
    {
        canvas = this.transform.GetChild(0).gameObject;
        slider = canvas.transform.GetChild(0).gameObject.GetComponent<Slider>();
        slider.gameObject.SetActive(false);
        slider.value = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.name == "Medis")
            {
                //GameObject canvas = hit.collider.gameObject.transform.GetChild(0).gameObject;
                slider.gameObject.SetActive(true);
                InvokeRepeating(nameof(DoSomething), 1f, 1f);
            }

        }
    }
    private void DoSomething()
    {
        k++;
        slider.value = (float)(k * 0.2);

        if (k == 5)
            Destroy(gameObject);

        //add to resources
    }
}
