using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    [Networked] public int score {get; set;}
    [SerializeField] public GameObject background;
    [SerializeField] public TextMeshProUGUI scoreNumber;
    [SerializeField] public Button special;


    void Start()
    {
        
    }


    public override void FixedUpdateNetwork()
    {
        scoreNumber.text = score.ToString();

        EnabledMoveSpecial();
    }

    
    private void EnabledMoveSpecial()
    {
        if (score < 10) return;
        ButtonScript buttonScript = FindAnyObjectByType<ButtonScript>();
        if (!buttonScript && !buttonScript.buttonMoveSpecial) return;
        buttonScript.buttonMoveSpecial.gameObject.SetActive(true);
    }
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void Rpc_GainPoints(int value)
    {
        score = score + value;
    }
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void Rpc_Special()
    {
        var buttonSpecial = special.GetComponent<Button>();
        if (score >= 10)
        {
            buttonSpecial.interactable = true;
        }
        else
        {
            buttonSpecial.interactable = false;
        }
    }
}
