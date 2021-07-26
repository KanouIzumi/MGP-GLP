using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    [Tooltip("Score reward for destorying enemy")]
    public int ItemReward;

    [Tooltip("Sound an Item is pick")]
    public AudioClip ItemAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Item get");
            //GameManager.Instance.ItemCount(ItemReward, ItemAudioClip);
            GameManager.Instance.itemCount(ItemReward, ItemAudioClip);
            Destroy(gameObject);

        }
    }
}
