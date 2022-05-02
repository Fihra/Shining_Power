using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text textHealth;
    public Player player;

    private void Update()
    {
        Debug.Log("In health Manager: " + player.OutputHealth());
        textHealth.text = player.OutputHealth().ToString() + "%";
    }

    //public void SetHealth()
    //{

    //}

}
