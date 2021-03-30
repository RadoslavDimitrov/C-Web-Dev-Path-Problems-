namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private static string errorMessage = "Invalid Data";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			List<Game> gamesToAdd = new List<Game>();
			List<Developer> developers = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();

			ImportGamesDto[] gamesDto = JsonConvert.DeserializeObject<ImportGamesDto[]>(jsonString);

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto))
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				DateTime releaseTime;

				bool isDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
					DateTimeStyles.None, out releaseTime);

                if (!isDateValid)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				if(gameDto.Tags.Length == 0)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				Game gameToAdd = new Game
				{
					Name = gameDto.Name,
					ReleaseDate = releaseTime,
					Price = gameDto.Price
				};

				var developer = developers.FirstOrDefault(x => x.Name == gameDto.Developer);

				if(developer == null)
                {
					developer = new Developer()
					{
						Name = gameDto.Developer
					};

					developers.Add(developer);
                };

				gameToAdd.Developer = developer;

				var genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);

				if(genre == null)
                {
					genre = new Genre()
					{
						Name = gameDto.Genre
					};

					genres.Add(genre);
                }

				gameToAdd.Genre = genre;

                foreach (var tagDto in gameDto.Tags)
                {
                    if (string.IsNullOrEmpty(tagDto))
                    {
						continue;
                    }

					Tag tag = tags.FirstOrDefault(x => x.Name == tagDto);

					if(tag == null)
                    {
						tag = new Tag()
						{
							Name = tagDto
						};

						tags.Add(tag);

						gameToAdd.GameTags.Add(new GameTag()
						{
							Game = gameToAdd,
							Tag = tag
						});
                    }
                    else
                    {
						gameToAdd.GameTags.Add(new GameTag()
						{
							Game = gameToAdd,
							Tag = tag
						});
					}
                }

				if(gameToAdd.GameTags.Count == 0)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				gamesToAdd.Add(gameToAdd);

				sb.AppendLine($"Added {gameToAdd.Name} ({gameToAdd.Genre.Name}) with {gameToAdd.GameTags.Count} tags");
            }

			context.Games.AddRange(gamesToAdd);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			ImportUsersDto[] usersDtos = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);

			List<User> usersToAdd = new List<User>();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto))
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				if(userDto.Cards.Length == 0)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				User userToAdd = new User()
				{
					FullName = userDto.FullName,
					Username = userDto.Username,
					Age = userDto.Age,
					Email = userDto.Email
				};

				foreach (var cardDto in userDto.Cards)
				{
					if (!IsValid(cardDto))
					{
						sb.AppendLine(errorMessage);
						break;
					}

					CardType type;
					bool isValidCardType = Enum.TryParse(cardDto.Type, out type);
					if (!isValidCardType)
					{
						sb.AppendLine(errorMessage);
						break;
					}

					Card card = new Card()
					{
						Cvc = cardDto.CVC,
						Number = cardDto.Number,
						Type = type,
						User = userToAdd
					};

					userToAdd.Cards.Add(card);
				}

				usersToAdd.Add(userToAdd);
				sb.AppendLine($"Imported {userToAdd.Username} with {userToAdd.Cards.Count} cards");
			}

			context.Users.AddRange(usersToAdd);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchasesDto[]),new XmlRootAttribute("Purchases"));

			var purchaseDtos = (ImportPurchasesDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

			List<Purchase> purchasesToAdd = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				DateTime date;

				bool isValidDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
					DateTimeStyles.None, out date);

                if (!isValidDate)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				PurchaseType purchaseType;

				bool isValidType = Enum.TryParse(purchaseDto.Type, out purchaseType);

                if (!isValidDate)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

				if(card == null)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

				if(game == null)
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				Purchase purchase = new Purchase()
				{
					Game = game,
					Card = card,
					Type = purchaseType,
					Date = date,
					ProductKey = purchaseDto.Key
				};

				purchasesToAdd.Add(purchase);
				sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

			context.Purchases.AddRange(purchasesToAdd);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}