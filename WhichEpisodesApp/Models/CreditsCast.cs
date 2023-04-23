using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class CreditsCast
	{
        [JsonPropertyName("id")]
        public int showId { get; set; }

        [JsonPropertyName("name")]
        public string? showName { get; set; }

        [JsonPropertyName("poster_path")]
        public string? posterPath { get; set; }

        [JsonPropertyName("credit_id")]
        public string? creditId { get; set; }

        public string? character { get; set; }

        [JsonPropertyName("episode_count")]
        public int episodeCount { get; set; }
    }
}

