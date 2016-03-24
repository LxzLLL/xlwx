using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:24:24
    /// 描述：异步任务完成事件推送
    /// </summary>
    public class BatchJobResult:IMessage
    {
        private MessageBatchJobResultEvent _msgBatchJobResultEntity = new MessageBatchJobResultEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private BatchJobResult(){ }
        public BatchJobResult( MessageBatchJobResultEvent msgBatchJobResultEntity )
        {
            this._msgBatchJobResultEntity = msgBatchJobResultEntity;
        }

        /// <summary>
        /// 接口，返回数据
        /// </summary>
        /// <returns></returns>
        public string MsgResponse()
        {
            string sRespData = string.Empty ;
            
            return sRespData;
        }
    }
}
