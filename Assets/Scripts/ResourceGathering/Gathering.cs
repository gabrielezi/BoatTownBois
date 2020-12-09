using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gathering : MonoBehaviour
{
    public Slider slider;
    public GameObject canvas;
    int k = 0;

    private Camera _camera;

    private void Start()
    {
        canvas = this.transform.GetChild(0).gameObject;
        slider = canvas.transform.GetChild(0).gameObject.GetComponent<Slider>();
        slider.gameObject.SetActive(false);
        slider.value = 0;
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.name == gameObject.name)
            {
                slider.gameObject.SetActive(true);
                InvokeRepeating(nameof(DoSomething), 1f, 1f);
            }
        }
    }

    private void DoSomething()
    {
        k++;
        slider.value = (float) (k * 0.2);

        if (k == 5)
        {
            if (gameObject.CompareTag("Wood_Resource"))
            {
                ResourceManager.Instance.AddResource(ResourceEnum.Wood, 100);
            }
            else if (gameObject.CompareTag("Stone_Resource"))
            {
                ResourceManager.Instance.AddResource(ResourceEnum.Stone, 50);
            }

            Destroy(gameObject);
        }
    }
}
