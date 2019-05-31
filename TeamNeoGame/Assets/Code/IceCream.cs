/******************************
 * Author: Nico
 * Date Last Edited: 5-30-2019
 * Description: Description
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCream : MonoBehaviour
{
	private Animator anim;
	public int count = 3;
	private int disp = 0;
    // Start is called before the first frame update
    void Start()
    {
    	anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ModNum(int num) {
    	count = num;
    	anim.SetInteger("Num", count);
    }

}
