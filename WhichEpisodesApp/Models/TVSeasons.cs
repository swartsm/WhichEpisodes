using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class TVSeasons
	{
        [JsonPropertyName("episode_count")]
        public int episodeCount { get; set; }

        [JsonPropertyName("season_number")]
        public int seasonNumber { get; set; }
    }
}

