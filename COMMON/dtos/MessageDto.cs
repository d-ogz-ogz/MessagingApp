﻿using COMMON.interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.dtos
{
    public class MessageDto:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? ChatId { get; set; }
        public string? Content { get; set; }
        public DateTime Adding { get; set; }
        public ChatDto? Chat { get; set; }

    }
}
