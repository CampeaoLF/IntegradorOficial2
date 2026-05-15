using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Fusion;

public class ButtonScript : NetworkBehaviour
{
    [Networked] public NetworkObject player { get; set; }
    [SerializeField] public GameManager gameManager;

    [Header("Botões de movimento base")]
    [SerializeField] public Button[] buttonsMoveBase;

    //[Header("Botão de movimento especial")]
    [Networked] public NetworkObject buttonMoveSpecial { get; set; }

    [Header("Sprite")]
    [SerializeField] public Sprite[] sprites;
    [SerializeField] public Sprite[] cenario;


    void Start()
    {



    }


    public override void FixedUpdateNetwork()
    {
        if (player == null && Runner != null)
        {
            
            player = Runner.GetPlayerObject(Runner.LocalPlayer);
        }
        if (gameManager.score >= 5 && cenario[0])
        {

            var scenarioAtual = gameManager.background.GetComponent<SpriteRenderer>();
            scenarioAtual.sprite = cenario[0];
        }
        if (gameManager.score >= 10 && cenario[1])
        {
            var scenarioAtual = gameManager.background.GetComponent<SpriteRenderer>();
            scenarioAtual.sprite = cenario[1];
        }



    }

    public void ClickMoveBaseFirst(Button botao)
    {
        

        if ( buttonsMoveBase[0])
        {

            var spriteAtual = player.GetComponent<SpriteRenderer>();
            if (spriteAtual != null)
            {
                spriteAtual.sprite = sprites[0];
            }
            if (buttonMoveSpecial)
            {
                spriteAtual.sprite = sprites[0];
            }
            gameManager.Rpc_GainPoints(1);
        }
        
    }

    public void ClickMoveBaseSecond()
    {
       

            var spriteAtual = player.GetComponent<SpriteRenderer>();
            if (spriteAtual != null)
            {
                spriteAtual.sprite = sprites[1];
            }
            if (buttonMoveSpecial)
            {
                spriteAtual.sprite = sprites[1];
            }
            gameManager.Rpc_GainPoints(5);
        

    }

    public void ClickMoveBaseThird()
    {
        if (buttonsMoveBase[2])
        {

            var spriteAtual = player.GetComponent<SpriteRenderer>();
            if (spriteAtual != null)
            {
                spriteAtual.sprite = sprites[2];
            }
            if (buttonMoveSpecial)
            {
                spriteAtual.sprite = sprites[2];
            }
            gameManager.Rpc_GainPoints(5);

        }

    }

    public void ClickMoveBaseSpecial(Button botao)
    {
        
        var spriteAtual = player.GetComponent<SpriteRenderer>();
        if (spriteAtual != null)
        {
            spriteAtual.sprite = sprites[3];
        }
        if (buttonMoveSpecial)
        {
            spriteAtual.sprite = sprites[3];
        }
            gameManager.Rpc_GainPoints(10);
    }


}
