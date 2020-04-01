using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collections : MonoBehaviour
{
    public Text display;
    private int money;
    public int target;
    public LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin") {
            money += 1;
            Destroy(collision.gameObject);
            display.text = "Money: " + money.ToString() + " / " + target.ToString();
            Debug.Log(money);
        }
        if (money >= target) {
            manager.NextLevel();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
