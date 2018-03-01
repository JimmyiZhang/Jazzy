using System;

namespace Jazzy.Infrastructure
{
    public class MessageResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public MessageResult()
        {
            this.Message = string.Empty;
        }

        public MessageResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        public void Succeed(string message)
        {
            this.Success = true;
            this.Message = message;
        }

        public void Fail(string message)
        {
            this.Success = false;
            this.Message = message;
        }
    }

    public class MessageResult<T> : MessageResult
    {
        public MessageResult() : base() { }

        public MessageResult(bool success, string message, T data)
            : base(success, message)
        {
            this.Data = data;
        }

        public MessageResult(bool success, string message)
            : this(success, message, default(T)) { }

        public T Data { get; set; }

        public void Succeed(T data)
        {
            this.Success = true;
            this.Message = string.Empty;
            this.Data = data;
        }
        public void Succeed(T data, string message)
        {
            this.Success = true;
            this.Message = message;
            this.Data = data;
        }
        public MessageResult ToResult()
        {
            return new MessageResult()
            {
                Success = this.Success,
                Message = this.Message
            };
        }

        public MessageResult ToResult(string message)
        {
            return new MessageResult()
            {
                Success = this.Success,
                Message = this.Success ? message : this.Message
            };
        }
    }
}