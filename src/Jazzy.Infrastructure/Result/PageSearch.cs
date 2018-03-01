namespace Jazzy.Infrastructure
{
    public class PageSearch
    {
        private int page = 1;
        private int size = 10;


        /// <summary>
        /// 当前页码
        /// </summary>
        public int Page
        {
            get
            {
                return this.page < 1 ? 1 : this.page;
            }
            set
            {
                this.page = value;
            }
        }
        
        /// <summary>
        /// 每页大小
        /// </summary>
        public int Size
        {
            get
            {
                return this.size < 1 ? 10 : this.size;
            }
            set
            {
                this.size = value;
            }
        }

        /// <summary>
        /// 跳过条数
        /// </summary>
        public int Skip
        {
            get
            {
                return (this.Page - 1) * this.Size;
            }
        }
    }
}
