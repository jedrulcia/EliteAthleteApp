using EliteAthleteApp.Contracts.Services;

namespace EliteAthleteApp.Services
{
	public class YoutubeService : IYoutubeService
	{
		public YoutubeService()
		{
		}

		// CONVERTS THE EXERCISE YOUTUBE LINK TO A READABLE FORM
		public string GetEmbeddedYouTubeLink(string videoLink)
		{
			if (string.IsNullOrEmpty(videoLink))
				return null;

			// Zapisz czas rozpoczęcia
			string startTime = null;

			// Obsługuje klasyczne, skrócone i embed linki
			string videoId = null;

			// Sprawdzenie różnych formatów linków
			if (videoLink.Contains("youtube.com/watch?v="))
			{
				videoId = videoLink.Split(new[] { "v=" }, StringSplitOptions.None).Last();
			}
			else if (videoLink.Contains("youtu.be/"))
			{
				videoId = videoLink.Split(new[] { "youtu.be/" }, StringSplitOptions.None).Last();
			}
			else if (videoLink.Contains("youtube.com/embed/"))
			{
				// Dla linku embed, wyodrębniamy videoId
				videoId = videoLink.Split(new[] { "embed/" }, StringSplitOptions.None).Last();

				// Sprawdź, czy link zawiera parametr start
				var uri = new Uri(videoLink);
				var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
				if (queryParams["start"] != null)
				{
					startTime = queryParams["start"];
				}
			}

			// Usunięcie dodatkowych parametrów dla standardowych linków
			if (videoLink.Contains("youtube.com/watch?v=") || videoLink.Contains("youtu.be/"))
			{
				var uri = new Uri(videoLink);
				var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);

				if (queryParams["t"] != null)
				{
					// Wyciągnij czas rozpoczęcia, przetwórz go na sekundy
					var timeParam = queryParams["t"];
					if (timeParam.EndsWith("s"))
					{
						// Czas w sekundach
						startTime = timeParam.TrimEnd('s');
					}
					else if (timeParam.EndsWith("m"))
					{
						// Czas w minutach
						startTime = (int.Parse(timeParam.TrimEnd('m')) * 60).ToString();
					}
					else if (timeParam.Contains("m"))
					{
						// Czas w minutach i sekundach (np. 1m30s)
						var timeParts = timeParam.Split('m');
						var minutes = int.Parse(timeParts[0]) * 60;
						var seconds = int.Parse(timeParts[1].TrimEnd('s'));
						startTime = (minutes + seconds).ToString();
					}
				}
			}

			// Jeśli znalazł videoId, buduje link embed
			if (!string.IsNullOrEmpty(videoId))
			{
				// Usuwanie dodatkowych parametrów, jeśli są
				videoId = videoId.Split(new[] { "&", "?" }, StringSplitOptions.None)[0];
				var embedUrl = "https://www.youtube.com/embed/" + videoId;

				// Dodawanie parametru czasu rozpoczęcia, jeśli istnieje
				if (!string.IsNullOrEmpty(startTime))
				{
					embedUrl += "?start=" + startTime;
				}

				return embedUrl;
			}

			return null; // lub zgłoś wyjątek, jeśli chcesz
		}
	}
}
