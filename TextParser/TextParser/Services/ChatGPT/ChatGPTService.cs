using System.Text;
using System.Text.Json;
using OpenAI.Chat;
using TextParser.Models.OpenAI;

namespace ChatGptConsoleApp.Services;

public class ChatGptService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "";
    private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";

    public ChatGptService()
    {
               
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public async Task<string> GetChatGptResponse(string? prompt)
    {
        var requestData = new ChatGPTRequest(
            "gpt-3.5-turbo",
            200,
            [ChatMessage.CreateUserMessage(prompt)]
        );

        string jsonRequest = JsonSerializer.Serialize(requestData);
        HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(_apiUrl, content);
        string jsonResponse = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ChatGPTResponse>(jsonResponse);
        return result.Choices[0].Message.Content.ToString();
    }
}