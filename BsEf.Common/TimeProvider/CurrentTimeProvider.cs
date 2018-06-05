using System;

namespace BsEf.Common.TimeProvider
{
    public class CurrentTimeProvider : ICurrentTimeProvider
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}