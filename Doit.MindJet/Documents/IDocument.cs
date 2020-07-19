using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.Documents
{
    /// <summary>
    /// 文档接口
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="fileName">文件路径</param>
        void Open(string fileName);

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="fileName">文件路径</param>
        void Save(string fileName);

    }
}
