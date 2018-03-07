
namespace Jazzy.Domain
{
    /// <summary>
    /// 城市
    /// </summary>
    public class City
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标题（全称）
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public CityCategory Category { get; set; }

        /// <summary>
        /// 名称首字母缩略词
        /// </summary>
        public string Initial { get; set; }

        /// <summary>
        /// 全局编码
        /// </summary>
        public int ParentCode { get; set; }

        /// <summary>
        /// 标记（备用）
        /// </summary>
        public string Tag { get; set; }
    }

    /// <summary>
    /// 城市类别
    /// </summary>
    public enum CityCategory
    {
        /// <summary>
        /// 省
        /// </summary>
        Province = 1,

        /// <summary>
        /// 市
        /// </summary>
        City = 2
    }
}
