using System.Runtime.Serialization;
using MongoDB.Bson;

namespace GildedRose;

[DataContract]
public class ItemDto
{
    [DataMember]
    public ObjectId _id { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public int SellIn { get; set; }
    [DataMember]
    public float Quality { get; set; }
    [DataMember]
    public bool IsConjured { get; set; }
    [DataMember]
    public string Type { get; set; }
}