namespace Jazzy.Infrastructure.Uuid
{
    public class UuidNumberSetting
    {
        private long workerId = 0;
        private long datacenterId = 0;

        public UuidNumberSetting SetWorkId(long id)
        {
            this.workerId = id;
            return this;
        }

        public UuidNumberSetting SetDatacenterId(long id)
        {
            this.datacenterId = id;
            return this;
        }

        internal IdWorker Build()
        {
            return new IdWorker(this.workerId, this.datacenterId);
        }
    }
}
