using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class TVShowInfoModel
	{
        [JsonPropertyName("number_of_seasons")]
        public int NumberofSeasons { get; set; }

        [JsonPropertyName("seasons")]
        public TVSeasons[] TVseason { get; set; }
    }
}

