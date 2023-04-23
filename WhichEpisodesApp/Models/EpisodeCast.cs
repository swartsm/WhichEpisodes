using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class EpisodeCast
	{
        [JsonPropertyName("name")]
        public string actorName { get; set; }
    }
}

