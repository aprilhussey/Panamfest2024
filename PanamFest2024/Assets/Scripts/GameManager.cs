using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	// Scores applied when landing a hit
	// Standard body shot
	[Tooltip("The score added for a body shot")]
    public int NormalScore;

    // Headshot/Critical strike
    [Tooltip("The score added for a critical hit")]
    public int CritScore;

    // Player's total score
    [Tooltip("The players total score (shoudln't need touching)")]
    public int PlayerScore;

    // Setting/Options objects
    [Tooltip("This will be found in the options/setting page")]
    [SerializeField] GameObject VolumeSlider;

    [Tooltip("")]
    [SerializeField] GameObject InvertedControlsToggle;

    [Tooltip("")]
    [SerializeField] GameObject InputMappingToggle;

    // In-game scripts
    [Tooltip("")]
    [SerializeField] AudioManager AudioManager;

    [Tooltip("")]
    [SerializeField] InputMapping InputMapping;

    [Tooltip("")]
    [SerializeField] PlayerController PlayerController;

    // Player Prefs
    PlayerPrefs Volume;
    PlayerPrefs InvertControls;
    PlayerPrefs FlipWheels;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InputMapping == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                //Debug.Log("Input Mapping assigned");
                InputMapping = GameObject.FindGameObjectWithTag("Player").GetComponent<InputMapping>();
            }
        }

        if (PlayerController == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                //Debug.Log("Player Controller assigned");
                PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            }
        }

        PlayerPrefs.SetFloat("Volume", VolumeSlider.GetComponent<UnityEngine.UI.Slider>().value);

        if (InvertedControlsToggle.GetComponent<UnityEngine.UI.Toggle>().isOn == true)
        {
            Debug.Log("Inverted on");
            PlayerPrefs.SetInt("InvertedControls", 1);
        }
        else if (InvertedControlsToggle.GetComponent<UnityEngine.UI.Toggle>().isOn == false)
        {
            Debug.Log("Inverted off");
            PlayerPrefs.SetInt("InvertedControls", 0);
        }

        if (InputMappingToggle.GetComponent<UnityEngine.UI.Toggle>().isOn == true)
        {
            PlayerPrefs.SetInt("FlipWheels", 1);
        }
        else if (InputMappingToggle.GetComponent<UnityEngine.UI.Toggle>().isOn == false)
        {
            PlayerPrefs.SetInt("FlipWheels", 0);
        }

        // Assigning PlayerPrefs
        if (AudioManager != null)
        {
            //for (int i = 0; i < AudioManager.GetComponent<AudioManager>().sounds.Length; i++)
            //{
            //    AudioManager.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
            //}

            AudioManager.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        }

        if (InputMapping != null)
        {
            if (PlayerPrefs.GetInt("FlipWheels") == 1)
            {
                InputMapping.OnSwitchInputLayout();
            }
            else if (PlayerPrefs.GetInt("FlipWheels") == 0)
            {
                InputMapping.OnSwitchInputLayout();
            }
        }

        if (PlayerController != null)
        {
            if (PlayerPrefs.GetInt("InvertedControls") == 1)
            {
                PlayerController.Inverted = true;
            }
            else if (PlayerPrefs.GetInt("InvertedControls") == 0)
            {
                PlayerController.Inverted = false;
            }
        }
    }

}
