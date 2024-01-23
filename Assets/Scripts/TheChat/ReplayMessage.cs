using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReplayMessage : MonoBehaviour
{
    public static ReplayMessage instance;
    private void Awake(){
        instance = this;
    }

   // public TMP_Text textField;
    public TMP_InputField inputField;
    TouchScreenKeyboard keyword;

    private OpenAIAPI api;
    private List<ChatMessage> messages;
    public string OpenAIKey;

    private string WhoIsTheSystem;
    private string TheFirstSystemMessage;

    [HideInInspector] public string StartMessage, BeforeMessage;

    [HideInInspector] public List<string> TheChatList = new List<string>();


    public void StartReplaying()
    {
        // This line gets your API key (and could be slightly different on Mac/Linux)
        // Environment.GetEnvironmentVariable(OpenAIKey, EnvironmentVariableTarget.User)
        api = new OpenAIAPI(OpenAIKey);
        StartConversation();
    }

    public void OpenKeyword(){
        keyword = TouchScreenKeyboard.Open("",TouchScreenKeyboardType.Default);
    }

    public void Send(){
        GetResponse();
    }

    private void StartConversation()
    {
        messages = new List<ChatMessage> {
            new ChatMessage(ChatMessageRole.System, "You're name is zou you live in zeralda, algeria, you are here to answer all the questions, you are chat gpt can get creative or fun to talk to but always to the point, your a personne and have feelings and can intract with other human")
        };

        inputField.text = "";
        string startString = "Hi, I am zou and i am here to answer all your questions, please don't hasitate and ask me anything.";
        TheChatList.Add(startString);
        ChatView.instance.UpdateScroll();
        // textField.text = startString;
        Debug.Log(startString);
    }

    private async void GetResponse()
    {
        if (inputField.text.Length < 1)
        {
            return;
        }

        // Fill the user message from the input field
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = inputField.text;
        

        // Add the message to the list
        messages.Add(userMessage);
        TheChatList.Add(string.Format(userMessage.Content));
        ChatView.instance.UpdateScroll();
        

        // Clear the input field
        inputField.text = "";

        // Send the entire chat to OpenAI to get the next message
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.9,
            MaxTokens = 50,
            Messages = messages
        });

        // Get the response message
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.rawRole, responseMessage.Content));

        // Add the response to the list of messages
        messages.Add(responseMessage);
        TheChatList.Add(string.Format(responseMessage.Content));
        ChatView.instance.UpdateScroll();


    }

    public void EndChat(){
       TheChatList.Clear(); 
    }
}
