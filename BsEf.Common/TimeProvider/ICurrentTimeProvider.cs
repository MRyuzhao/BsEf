using System;

namespace BsEf.Common.TimeProvider
{
    public interface ICurrentTimeProvider
    {
        DateTime CurrentTime();
    }
}