using MongoDB.Bson;
using System;
using Utility.Enums;

namespace Data
{
    public class CommonEvent<T> where T : class
    {
        public CommonEvent(T modelEvent, string commandName, DateTime eventDate, TypeEvent typeEvent, string nameEvent)
        {
            ModelEvent = modelEvent;
            CommandName = commandName;
            EventDate = eventDate;
            TypeEvent = typeEvent;
            NameEvent = nameEvent;
            Id = UniqueIdentifier.New;
        }

        public string Id { get; set; }
        public T ModelEvent { get; set; }
        public string CommandName { get; set; }
        public DateTime EventDate { get; set; }
        public TypeEvent TypeEvent { get; set; }
        public string NameEvent { get; set; }
    }

    public static class UniqueIdentifier
    {
        public static string New => ObjectId.GenerateNewId().ToString();
    }
}
