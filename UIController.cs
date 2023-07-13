using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button buttonStartServer;
    [SerializeField]
    private UnityEngine.UI.Button buttonShutDownServer;
    [SerializeField]
    private UnityEngine.UI.Button buttonConnectClient;
    [SerializeField]
    private UnityEngine.UI.Button buttonDisconnectClient;
    [SerializeField]
    private UnityEngine.UI.Button buttonSendMessage;
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private TMP_InputField inputFieldName;
    [SerializeField]
    private TextField textField;
    [SerializeField]
    private Server server;
    [SerializeField]
    private Client client;

    private void Start()
    {
        buttonStartServer.onClick.AddListener(() => StartServer());
        buttonShutDownServer.onClick.AddListener(() => ShutDownServer());
        buttonConnectClient.onClick.AddListener(() => Connect());
        buttonDisconnectClient.onClick.AddListener(() => Disconnect());
        buttonSendMessage.onClick.AddListener(() => SendMessage());
        client.onMessageReceive += ReceiveMessage;
    }

    private void StartServer()
    {
        server.StartServer();
    }    private void ShutDownServer()     {        server.ShutDownServer();    }    private void Connect()
    {
        client.Connect();
    }
    private void Disconnect()
    {
        client.Disconnect();
    }
    private void SendMessage()
    {
        client.SendMessage(inputField.text);
        inputField.text = "";
        client.SendMessage(inputFieldName.text);
        inputFieldName.text = "";
    }
    public void ReceiveMessage(object message)
    {
        textField.ReceiveMessage(message);
    }}