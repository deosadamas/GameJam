using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breakableobject : MonoBehaviour
{

    public GameObject brokenbits;
    public bool collideWithBits;
    public Slider timerBar;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            BreakIt();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
            BreakIt();

    }




    public void BreakIt()
    {
        Destroy(this.gameObject);
        GameObject broke = (GameObject)Instantiate(brokenbits, transform.position, Quaternion.identity);
        
        foreach (Transform child in broke.transform)
        {
            child.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(5f, 10f));
        }
        Debug.Log("debut if");
        if (timerBar.GetComponent<TimeBarManager>().isDangerous == false)
        {
            timerBar.GetComponent<TimeBarManager>().CurrentTime = 10;
        }
        if (timerBar.GetComponent<TimeBarManager>().isDangerous == true)
        {
            timerBar.GetComponent<TimeBarManager>().CurrentTime = 0;
        }
        Debug.Log("fin if");
        StartCoroutine(destroy(broke));

    }
    
    IEnumerator destroy(GameObject objects)
    {
        Debug.Log("bla");
        yield return new WaitForSeconds(2.0f);
        Destroy(objects);
    }


}
