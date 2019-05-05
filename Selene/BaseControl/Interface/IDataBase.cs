using Selene.BaseControl.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.BaseControl.Interface
{
    public interface IDataBase
    {
        void SetFormModel<TModel>(TModel model) where TModel : class,new();

        void SetFormModel<TModel>(string modelName,TModel model) where TModel : class,new();

        TModel GetFormModel<TModel>(FormObjectModel objModel = FormObjectModel.New) where TModel : class,new();

        TModel GetFormModel<TModel>(string modelName,FormObjectModel objModel = FormObjectModel.New) where TModel : class,new();

        FormMode OperatorFormMode { get; set; }
    }
}
