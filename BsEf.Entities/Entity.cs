using System;

namespace BsEf.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public int CreateUserId { get; set; }

        public DateTime CreateTime { get; set; }

        public int EditUserId { get; set; }

        public DateTime? EditTime { get; set; }
    }
}