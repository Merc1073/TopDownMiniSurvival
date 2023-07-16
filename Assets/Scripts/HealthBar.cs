using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject healthBar;

    Camera cam;

    public Vector3 offset = new Vector3(0, 10, 0);

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 position = cam.WorldToScreenPoint(this.transform.position);

        healthBar.transform.position = position + offset;
    }

}
