using System;
using System.Text.Json.Serialization;

namespace WhichEpisodesApp.Models
{
	public class TVEpisodeCreditsModel
	{
        [JsonPropertyName("cast")]
        public EpisodeCast[] episodeCast { get; set; }

        [JsonPropertyName("guest_stars")]
        public EpisodeGuestStars[] episodeGuestStars { get; set; }
    }
}

