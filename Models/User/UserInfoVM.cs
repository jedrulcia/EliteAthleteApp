﻿using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
	public class UserInfoVM
	{
		public string? Id { get; set; }
		// STRINGS etc.
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		public string LastName { get; set; }
		public string? DateOfBirth { get; set; }
		public string? ImageUrl { get; set; }
		public string? CoachFullName { get; set; }
	}
}