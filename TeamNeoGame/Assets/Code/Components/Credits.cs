/******************************
 * Author: Nico
 * Description: scrolls and manages the credits
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
	private Rigidbody2D rigid;
	public KeyCode skipkey;
	public float timeToEnd = 40;
	private float timer = 0;
	public float waitEnd = 3;
	private float waitTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void End() {
        CombatInfo.CombatsFinished = 0;
            MapNodeManager.ResetGame();
        Debug.Log(CombatInfo.CombatsFinished);
            SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
    	waitTimer += Time.deltaTime;
    	if (waitTimer >=waitEnd) {
    		timer += Time.deltaTime;
    		if (timer >= timeToEnd) {
    			End();
    		}
    		if (Input.GetKeyDown(skipkey)) {
    			End();
    		}
			rigid.velocity = new Vector2(0, 1);   
		}     
    }
}
