using System;
using System.Collections.Generic;
using System.Text;

namespace Jazzy.Infrastructure.Test
{
    public class SimpleGeneralType : SimpleInterface
    {
        public string Name { get; set; }
    }

    public class SimpleGenericType<T> : SimpleInterface
    {
        public T Data { get; set; }
    }

    public interface SimpleInterface
    { }
}
