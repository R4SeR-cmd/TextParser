using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Chat;

namespace TextParser.Models.OpenAI;

public class ChatGPTResponse
{
    public string Id { get; set; }
    public List<ChatChoice> Choices { get; set; }

    public ChatGPTResponse()
    {
        Choices = new List<ChatChoice>();
    }
}