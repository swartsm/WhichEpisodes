using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class TVEpisodeInfoModel
	{
        [JsonPropertyName("name")]
        public string episodeName { get; set; }

        [JsonPropertyName("season_number")]
        public int seasonNumber { get; set; }

        [JsonPropertyName("episode_number")]
        public int episodeNumber { get; set; }

        [JsonPropertyName("still_path")]
        public string stillPath { get; set; }

        public string overview { get; set; }
    }
}

