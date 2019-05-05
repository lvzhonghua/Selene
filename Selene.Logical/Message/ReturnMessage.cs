using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical.Message
{
    public class ReturnMessage
    {
        public int Status { get; set; }
        public bool Ok
        {
            get
            {
                return Status == 200;
            }
        }

        private object commonObject;

        public void SetObject(object obj)
        {
            this.commonObject = obj;
        }

        public object GetObject()
        {
            return commonObject;
        }

        public TEntity GetEntity<TEntity>() where TEntity:class
        {
            return commonObject as TEntity;
        }

        public string Message { get; set; }

        public ReturnMessage() {
            this.Status = MessageStatus.Success;
        }

        public ReturnMessage(int status)
        {
            this.Status = status;
        }

        public ReturnMessage(string message)
        {
            this.Message = message;
        }

        public ReturnMessage(int status,string message)
        {
            this.Status = status;
            this.Message = message;
        } 
    }
}
