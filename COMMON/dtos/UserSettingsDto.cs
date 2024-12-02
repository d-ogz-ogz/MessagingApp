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
    public class UserSettingsDto : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string ProfilePic { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }

        public List<ChatDto>? Chats { get; set; }

    }
}
