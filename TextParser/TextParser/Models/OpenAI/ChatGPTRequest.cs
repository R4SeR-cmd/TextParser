using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Chat;

namespace TextParser.Models.OpenAI;

public class ChatGPTRequest
{
    public string Model { get; set; }
    public int MaxTokens { get; set; }
    public ChatMessage[] Messages { get; set; }

    public ChatGPTRequest(string model, int maxTokens, ChatMessage[] messages)
    {
        Model = model;
        MaxTokens = maxTokens;
        Messages = messages;
    }
}