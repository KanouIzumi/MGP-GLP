using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveBin : MonoBehaviour
{
    public int distance = 10;
    public Text itemsUpdate;
    // Start is called before the first frame update

    public int itemsCollected;


  void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }


    private void Update()
    {

        if(itemsCollected>=5)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        
        if (other.gameObject.tag == "Reduce")
        {
         
            SceneManager.LoadScene("GameLose");

        }

        if (other.gameObject.tag == "Recycle")
        {
            Destroy(other.gameObject);
            itemsCollected++;
            itemsUpdate.text = "Recycled items " + itemsCollected.ToString();

        }
    }


}
