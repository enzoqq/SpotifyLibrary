using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Caricamento_Musica;
using SpotifyWebApi.Models;

namespace ClientSpotify
{
    class Program
    {
        static void Main()
        {
            DatabaseManager.RunAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }


    }
}
