using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class PersonTVCreditsModel
	{
        [JsonPropertyName("cast")]
        public CreditsCast[] creditsCast { get; set; }

        //could also do CreditsCrew
    }
}

