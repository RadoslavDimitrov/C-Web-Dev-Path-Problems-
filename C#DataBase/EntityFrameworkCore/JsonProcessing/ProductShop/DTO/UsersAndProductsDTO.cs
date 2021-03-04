using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTO
{
    public class UsersAndProductsDTO
    {
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }
        [JsonProperty("users")]
        public List<UserSoldProductsDTO> Users { get; set; }
    }
}
