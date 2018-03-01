namespace Jazzy.Component
{
    /// <summary>
    /// 业务单元操作接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交工作单元
        /// </summary>
        /// <returns></returns>
        void Commit();

        /// <summary>
        /// 回滚工作单元
        /// </summary>
        void Rollback();

        /// <summary>
        /// 获取跟踪对象
        /// </summary>
        /// <returns></returns>
        IUnitOfTrack GetTrack();
    }
}
