using COMMON.interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.dtos
{
    public class UserDto : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Email { get; set; }
        public bool? Consent { get; set; }
        public bool? Inform { get; set; }
        public int PhoneNumber { get; set; }

        public List<ChatDto>? Chats { get; set; }

    }
}
