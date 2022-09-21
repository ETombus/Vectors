using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Vectors : ProcessingLite.GP21
{
    private float spaceBetweenLines = 0.2f;
    private Vector2 m_mPosHolder;
    public GameObject m_peg;

    void Start()
    {
        /*Background(Color.white);
        Stroke(255,0,0,255);
        Fill(255,255,255,255);

        for (int i = 0; i < Height; i++)
        {
            Line(i, i, i+1, i+1);
        }
        
        Circle(Width/2,0,2);
        Circle(Width/2,Height,2);*/
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        
        var m_mousePos = new Vector2(MouseX,MouseY);

        if(Input.GetMouseButtonDown(0))
            m_mPosHolder = new Vector2(MouseX, MouseY);

        if(Input.GetMouseButton(0))
        {
            Circle(m_mPosHolder.x,m_mPosHolder.y,1f);

            float maxLength = 2.5f;
            var m_mouseClamp = m_mousePos - m_mPosHolder;
            m_mouseClamp = Vector2.ClampMagnitude(m_mouseClamp, maxLength);
            var m_newLength = m_mPosHolder + m_mouseClamp;
            /*m_mouseClamp = new Vector2(Mathf.Clamp(MouseX,(m_mPosHolder.x-maxLength),m_mPosHolder.x+maxLength), 
                Mathf.Clamp(MouseY,m_mPosHolder.y-maxLength,m_mPosHolder.y+maxLength));*/
            Line(m_mPosHolder.x,m_mPosHolder.y,m_newLength.x,m_newLength.y);
        }

        if(Input.GetMouseButtonUp(0))
        {
            var peg = Instantiate(m_peg, new Vector3(m_mPosHolder.x, m_mPosHolder.y, 0f), Quaternion.identity);
            peg.gameObject.GetComponent<Rigidbody2D>().AddForce((m_mPosHolder - m_mousePos) * 100f);
        }


    }
}
