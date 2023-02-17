using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class AxeSwing : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed;
    public GameObject player;
    private PlayerController playerScript;
    private float buttonDownTime;
    public float timeScale;
    public GameObject fill15;
    public GameObject fill30;
    public GameObject fill50;
    public GameObject fill70;
    public GameObject fill85;
    public GameObject fill100;

    void Start()
    {
        buttonDownTime = 0.0f;
        playerScript = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (buttonPressed)
        {
            buttonDownTime += Time.deltaTime;
        }
        else
            buttonDownTime = 0.0f;

        if (buttonDownTime > timeScale)
            buttonDownTime = 0.0f;
        setFill(buttonDownTime);
    }
    private void SwingAxe(float time)
    {
        if (time == 0.0f)
            return;
        if (fill100.activeSelf == true)
        {
            playerScript.Chop(2f);
        }
        else if (fill85.activeSelf == true)
        {
            playerScript.Chop(1.5f);
        }
        else if (fill70.activeSelf == true)
        {
            playerScript.Chop(1f);
        }
        else if (fill50.activeSelf == true)
        {
            playerScript.Chop(0.7f);
        }
        else if (fill30.activeSelf == true)
        {
            playerScript.Chop(0.15f);
        }
        else if (fill15.activeSelf == true)
        {
            playerScript.Chop(0.07f);
        }
        else
            playerScript.Chop(0);
    }
    private void setFill(float time)
    {
        if (time > timeScale * .077f)
        {
            if (time > timeScale * 0.923f)
                fill15.SetActive(false);
            else
                fill15.SetActive(true);
        }
            
        if (time > timeScale * 0.154f)
        {
            if (time > timeScale * 0.846f)
                fill30.SetActive(false);
            else
                fill30.SetActive(true);
        }
            
        if (time > timeScale * 0.231f)
        {
            if (time > timeScale * 0.769f)
                fill50.SetActive(false);
            else
                fill50.SetActive(true);
        }
            
        if (time > timeScale * 0.308f)
        {
            if (time > timeScale * 0.692f)
                fill70.SetActive(false);
            else
                fill70.SetActive(true);
        }
            
        if (time > timeScale * 0.385f)
        {
            if(time > timeScale * 0.615f)
                fill85.SetActive(false);
            else
                fill85.SetActive(true);
        }
            
        if (time > timeScale * 0.462f)
        {
            if(time > timeScale * 0.539f)
                fill100.SetActive(false);
            else
                fill100.SetActive(true);
        }
        if(time == 0)
        {
            fill100.SetActive(false);
            fill85.SetActive(false);
            fill70.SetActive(false);
            fill50.SetActive(false);
            fill30.SetActive(false);
            fill15.SetActive(false);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        Debug.Log("Button Down");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        SwingAxe(buttonDownTime);
        Debug.Log("Button Up");
    }
}
