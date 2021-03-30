namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            

            var gamesByGenres = context.Genres
                .ToArray()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Games = x.Games
                    .Where(g => g.Purchases.Any())
                    .Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                        Players = g.Purchases.Count
                    })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

			return jsonResult;
				
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{



            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(storeType);

            var result = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                            .ToArray()
                            .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                            .OrderBy(p => p.Date)
                            .Select(p => new ExportPurchaseWithGameDto
                            {
                                CardNumber = p.Card.Number,
                                Cvc = p.Card.Cvc,
                                Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                Game = new ExportGameDto
                                {
                                    Title = p.Game.Name,
                                    Genre = p.Game.Genre.Name,
                                    Price = p.Game.Price
                                }
                            })
                            .ToArray(),
                    TotalSpent = context.Purchases
                    .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                    .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Length > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();


            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, result, namespaces);

            return sb.ToString().Trim();
        }
	}
}