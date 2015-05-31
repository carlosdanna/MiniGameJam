using UnityEngine;
using System.Collections;

public class _CreditButtonScript : MonoBehaviour {
    // === Variables
    public GameObject[] m_Pages;
    int m_iCurrentPage = 0;

	// Use this for initialization
	void Start () {
        LoadPage();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // ===== Page Functions ===== //
    void LoadPage()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == m_iCurrentPage)
                m_Pages[i].gameObject.SetActive(true);
            else
                m_Pages[i].gameObject.SetActive(false);
        }
    }

    public void NextPage()
    {
        m_iCurrentPage++;
        if (m_iCurrentPage >= 5)
            m_iCurrentPage = 0;
        LoadPage();
    }

    public void PrevPage()
    {
        m_iCurrentPage--;
        if (m_iCurrentPage < 0)
            m_iCurrentPage = 4;
        LoadPage();
    }
    // ========================== //
}
