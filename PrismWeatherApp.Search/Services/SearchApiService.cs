﻿using Newtonsoft.Json;
using PrismWeatherApp.Core.Models;
using PrismWeatherApp.Search.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrismWeatherApp.Search.Services
{
    public class SearchApiService : ISearchApiService
    {
        public async Task<CitiesResult> GetCities(string city)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    if (city == String.Empty || city == null || city.Length < 3)
                    {
                        throw new ArgumentNullException();
                    }
                    var response = await httpClient.GetAsync($"https://geocoding-api.open-meteo.com/v1/search?name={city}&count=3&language=en&format=json").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    string jsonContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<CitiesResult>(jsonContent);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured: {ex.Message}");
                    return null;
                }
            }
        }
        public async Task<Temperature> GetTemperature(double latitiude, double longitiude)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitiude}&longitude={longitiude}&hourly=temperature_2m").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    string jsonContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<Temperature>(jsonContent);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured: {ex.Message}");
                    return null;
                }
            }
        }
    }
