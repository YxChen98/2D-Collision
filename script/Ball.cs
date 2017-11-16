using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    bool m_isHit = false;
    Vector3 m_startPos;
    SpriteRenderer m_spriteRenderer;

	// Use this for initialization
	void Start () {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	bool IsHit()
    {
        m_isHit = false;

        Vector3 ms = Input.mousePosition;
        ms = Camera.main.ScreenToWorldPoint(ms);//Screen coordinates changed to world coordinates
        Vector3 pos = this.transform.position; //Get the position of the ball

        float w = m_spriteRenderer.bounds.extents.x;//Get width and height of the ball
        float h = m_spriteRenderer.bounds.extents.y;

        if(ms.x>pos.x-w && ms.x<pos.x+w && ms.y>pos.y-h && ms.y < pos.y + h)
        {
            m_isHit = true;
            return true;
        }

        return m_isHit;
    }

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0) && IsHit())//If mouse L pressed & hit the ball
        {
            m_startPos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0) && m_isHit)//If released
        {
            Vector3 endPos = Input.mousePosition;
            Vector3 v = (m_startPos - endPos) * 4.0f; //Direction of motion
            this.GetComponent<Rigidbody2D>().isKinematic = false;//Not controlled by script now
            this.GetComponent<Rigidbody2D>().AddForce(v);
        }
	}
}
