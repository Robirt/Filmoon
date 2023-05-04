﻿using Filmoon.Entities;
using Filmoon.Requests;
using Filmoon.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Filmoon.Services
{
    public class UsersService
    {
        private HttpClient HttpClient { get; }

        public async Task<SignInResponse> SignInAsync(SignInRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync("/Users/SignIn", request);

            return await response.Content.ReadFromJsonAsync<SignInResponse>();
        }

        public async Task<ActionResponse> SignUpAsync(SignUpRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync("/Users/SignUp", request);
            return await response.Content.ReadFromJsonAsync<ActionResponse>();
        }

        public async Task SignOutAsync()
        {

        }

        public async Task<UserEntity> GetUserByUserName()
        {
            return await HttpClient.GetFromJsonAsync<UserEntity>("/Users");
        }
    }
}
