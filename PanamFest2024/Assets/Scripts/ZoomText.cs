using UnityEngine;

public class ZoomText : MonoBehaviour
{

    public GameObject zoomText;
    public GameObject shootText;

    public bool hasTutorialHappened = false;




    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (hasTutorialHappened == true)
        {
            shootText.SetActive(false);
        }
    }

}
