using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Simon : MonoBehaviour {

    [SerializeField] float lightUpTime;
    [SerializeField] Color thisColor;
    [SerializeField] ParticleSystem ps;
    GameManager_Simon gm;
    Animation anim; 
    SpriteRenderer sRenderer;
    [SerializeField]bool leftColliderBool = true;

    //assign the same index as in the array on gm
    public int ButtonIndex { get; set; }

    private void Awake()
    {
        //References to objects / components
        anim = GetComponent<Animation>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager_Simon>();
        sRenderer = GetComponent<SpriteRenderer>();        
        
    }

   // private void OnMouseDown()
   // {
        
        //display button colour
     //   DisplayButton();
        
  //  }

    

    void DisplayButton()
    {
        //animate
        anim.clip = anim.GetClip("ButtonOnClick");
        anim.Play(); ;

        ps.transform.gameObject.SetActive(true);
        ps.Play();

        //tell the GM which button was pressed
        gm.ButtonPressed(ButtonIndex);

    }

    public void EnableCollider()
    {
        Debug.Log("EnableButtons called");
        gameObject.GetComponent<CircleCollider2D>().enabled = true;


    }

    public void DisableCollider()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        

    }

    IEnumerator DisableColliderForTime(float t)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(t);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MouseTrail" && leftColliderBool == true)
        {
            leftColliderBool = false;
            Debug.Log("triiger has entered!");
           // StartCoroutine(DisableColliderForTime(anim.GetClip("ButtonOnClick").length));
            DisplayButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MouseTrail")
        {
            leftColliderBool = true;
        }
    }








}
