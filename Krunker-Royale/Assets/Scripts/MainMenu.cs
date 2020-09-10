using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] KrunkerRoyaleNetworkManager manager;
    [SerializeField] TMP_InputField ipInput;
    [SerializeField] TMP_InputField nameInput;

    public string playerName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void JoinGame()
    {
        manager.networkAddress = ipInput.text;
    }

    public void addNameToManager()
    {
        manager.playerNamesList.Add(nameInput.text);
    }
}
