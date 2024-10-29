using COMMON.interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.dtos
{
    public class ChatDto:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public ReceiverDto Receiver { get; set; }
        public List<MessageDto>? Messages { get; set; }
    }
}
