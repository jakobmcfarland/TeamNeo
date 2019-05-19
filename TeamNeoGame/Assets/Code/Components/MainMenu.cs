using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI[] options;
    public List<GameObject> menuItems;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode pickKey;
    public int selected = 0;

    public Color deactiveColor;
    public Color activeColor;

    public float menuItemXOffset;

    bool dirty = true;

    // Start is called before the first frame update
    void Start()
    {
        options = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        menuItems.Add( GameObject.Find("Start Game") );
        menuItems.Add(GameObject.Find("Credits") );
        menuItems.Add(GameObject.Find("Exit") );

        menuItemXOffset = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown(upKey))
        {
            if (selected == options.Length - 1)
            {
                selected = 0;
            }
            else
            {
                selected++;
            }

            dirty = true;
        }
        else if (Input.GetKeyDown(downKey))
        {
            if (selected == 0)
            {
                selected = options.Length - 1;
            }
            else
            {
                selected--;
            }

            dirty = true;
        }
        if (Input.GetKeyDown(pickKey))
        {
            switch (selected)
            {
                case 0:
                    SceneManager.LoadScene("Map");
                    break;
                case 1:
                    SceneManager.LoadScene("Credits");
                    break;
                case 2:
                    Application.Quit();
                    break;
                default:
                    print("This really shouldn't be happening");
                    break;
            }
        }

        if (dirty)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selected)
                {
                    options[i].enabled = true;
                    menuItems[i].GetComponent<TextMeshProUGUI>().color = activeColor; 
                    //menuItems[i].GetComponent<Transform>().position -= new Vector3(menuItemXOffset, 0.0f, 0.0f);
                }
                else
                {
                    options[i].enabled = false;
                    menuItems[i].GetComponent<TextMeshProUGUI>().color = deactiveColor;
                    //menuItems[i].GetComponent<Transform>().position += new Vector3(menuItemXOffset, 0.0f, 0.0f);
                }
            }

            dirty = false;
        }
    }
}
