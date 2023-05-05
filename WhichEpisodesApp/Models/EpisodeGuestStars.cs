using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class EpisodeGuestStars
	{
        [JsonPropertyName("name")]
        public string guestStarName { get; set; }
    }
}