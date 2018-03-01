using System.Collections.Generic;

namespace Jazzy.Infrastructure
{
    public class PageResult<T>
    {
        public int TotalRecords { get; set; }

        public IEnumerable<T> DataSource { get; set; }

        public PageResult(int totalRecords, IEnumerable<T> dataSource)
        {
            this.TotalRecords = totalRecords;
            this.DataSource = dataSource;
        }
    }
}