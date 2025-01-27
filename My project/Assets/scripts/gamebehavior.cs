using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class gamebehavior : MonoBehaviour
{
    public bool showwinscreen = false;
    private int _itemscollected = 0;
    private int _playerhp = 10;
    public bool get;
    public bool set;

    public string labeltext = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public int Items
    {
        get
        {
            return _itemscollected;
        }
        set
        {
            _itemscollected = value;
            if(_itemscollected >= maxItems)
            {
                labeltext = "You found them all!";

                showwinscreen = true;

                Time.timeScale = 0F;
            }
            else
            {
                labeltext = "You found an item! only " + (maxItems - _itemscollected) + " More to go!";
            }
            Debug.LogFormat("Items: {0}", _itemscollected);
        }
    }

    private int HP
    {
        get { return _playerhp; }
        set
        {
            _playerhp = value;
            Debug.LogFormat("lives: {0}", _playerhp);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerhp);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemscollected);
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labeltext);

        if (showwinscreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);

                Time.timeScale = 1.0f;
            }
        }
    }
}
