using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private Button incrementButton;

    private void Update()
    {
        SharedCounter counter = SharedCounter.Instance;

        bool canClick = NetworkClient.isConnected && NetworkClient.localPlayer != null && counter != null && counter.isClient;

        incrementButton.interactable = canClick;

        counterText.text = canClick 
        ? $"Contatore: {counter.value}"
        : "Avvia Host o collegati come Client";
    }

    public void OnIncrementClicked()
    {
        if(NetworkClient.localPlayer == null)
            return;

        PlayerCounter player = NetworkClient.localPlayer.GetComponent<PlayerCounter>();

        if(player != null)
        {
            player.RequestIncrement();
        }
    }

}
