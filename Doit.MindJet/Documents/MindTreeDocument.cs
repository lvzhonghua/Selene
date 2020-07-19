using Doit.MindJet.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.Documents
{
    /// <summary>
    /// 脑图文档
    /// </summary>
    public class MindTreeDocument : IDocument
    {
        /// <summary>
        /// MindTree对象
        /// </summary>
        public MindTree MindTree { get; private set; }

        public MindTreeDocument(MindTree mindTree)
        {
            this.MindTree = mindTree;
        }
        public void Open(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
