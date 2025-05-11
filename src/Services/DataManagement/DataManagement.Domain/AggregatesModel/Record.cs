using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataManagement.Domain.AggregatesModel
{
    public record DataRecord
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("Data")]
        public string Data { get; set; }
    };
}
