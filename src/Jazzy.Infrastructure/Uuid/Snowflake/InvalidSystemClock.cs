using System;

namespace Jazzy.Infrastructure.Uuid
{
    public class InvalidSystemClock : Exception
    {      
        public InvalidSystemClock(string message) : base(message) { }
    }
}