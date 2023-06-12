using System;

namespace WhichEpisodesApp.Models
{
    public class KeyVaultModel {
        public static string keyVaultValue { get; set; }

        public KeyVaultModel(string kvvalue)
        {
            keyVaultValue = kvvalue;
        }
    }
   
}