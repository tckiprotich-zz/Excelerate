using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace Career_Connect.Api.Services
{
    /// <summary>
    /// Represents a service for creating new connections.
    /// </summary>
    public class CreateConnectionService : ICreateConnectionService
    {
        private readonly string openAiApiKey;
        private readonly OpenAIAPI openAiApi;
        private readonly HttpClient httpClient;

        public CreateConnectionService()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            openAiApiKey = configuration["AppSettings:OpenAiApiKey"];
            

            openAiApi = new OpenAIAPI(openAiApiKey);
            httpClient = new HttpClient();
        }

        /// <summary>
        /// OpenAI API call to create a new connection/networking message.
        /// </summary>
        public async Task<ServiceResponse<List<ResponseModel>>> CreateConnection(NetworkModel newConnection)
        {
            try
            {
                CompletionRequest completionRequest = new CompletionRequest();
                completionRequest.Prompt = $"Hello, I am {newConnection.Intro}, and I saw a job listing for {newConnection.TargetTitle} at {newConnection.TargetCompany}. I am interested in networking and would like to connect with you to learn more about the position and gain insights into the industry. Thank you for considering my request." + "\n\n" + "Always generate a new message for sending mesage to target connection for consideration for the listed job ";
                completionRequest.Model = Model.DavinciText;
                completionRequest.MaxTokens = 1024;
                completionRequest.Temperature = 0.7;

                var response = await openAiApi.Completions.CreateCompletionAsync(completionRequest);
                var intro = response.Completions[0].Text;

                // Console.WriteLine(intro);

                // Convert to response model
                var responseModel = new ResponseModel();
                responseModel.TargetTitle = newConnection.TargetTitle;
                responseModel.TargetCompany = newConnection.TargetCompany;
                responseModel.Message = intro;

                var responseData = new List<ResponseModel> { responseModel };

                return ServiceResponse<List<ResponseModel>>.SuccessResponse(responseData, "Successfully created a new connection message.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ResponseModel>>.ErrorResponse(ex.Message, "Error creating a new connection message.");
            }
        }
    }
}