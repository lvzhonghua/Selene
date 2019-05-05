using Selene.BaseControl.Enums;
using Selene.BaseControl.Interface;
using Selene.BaseControl.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.BaseControl
{
    public class DataFormBase : Form, IDataBase
    {
        //0 原始，1新增，2parent
        private Object[] objects = null;
        public DataFormBase()
        {
            objects = new object[3];
        }

        private Dictionary<string, object> objectDict = new Dictionary<string, object>();


        public virtual void SetFormModel<TModel>(TModel model) where TModel : class,new()
        {
            SetFormModel<TModel>("", model);
        }

        public TModel GetFormModel<TModel>(FormObjectModel objModel = FormObjectModel.New) where TModel : class,new()
        {
            return GetFormModel<TModel>("", objModel);
        }

        public void CollectData<TModel>(string modelName) where TModel : class,new()
        {
            TModel model = null;
            if (string.IsNullOrEmpty(modelName))
            {
                model = objects[0] as TModel;
            }
            else
            {
                if (objectDict.ContainsKey(modelName))
                {
                    model = objectDict[modelName] as TModel;
                }
            }

            var newModel = DataUtil.CollectData<TModel>(this, null, modelName, model);

            if (string.IsNullOrEmpty(modelName))
            {
                objects[1] = newModel;
            }
            else
            {
                objectDict[modelName] = newModel;
            }
        }

        private FormMode operatorFormMode = FormMode.Select;
        [Browsable(false)]
        public FormMode OperatorFormMode
        {
            get
            {
                return operatorFormMode;
            }
            set
            {
                operatorFormMode = value;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFormBase));
            this.SuspendLayout();
            // 
            // DataFormBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataFormBase";
            this.ResumeLayout(false);

        }
        


        public void SetFormModel<TModel>(string modelName, TModel model) where TModel : class, new()
        {

            if (this.operatorFormMode == FormMode.Add)
            {
                if (!string.IsNullOrEmpty(modelName))
                {
                    objectDict.Add(modelName, model);
                }
                else
                {
                    objects[2] = model;
                }
            }
            else if (this.operatorFormMode == FormMode.Edit || this.operatorFormMode == FormMode.Select)
            {
                if (!string.IsNullOrEmpty(modelName))
                {
                    objectDict.Add(modelName, model);
                }
                else
                {
                    objects[0] = model;
                }

                DataUtil.SetDataModel<TModel>(this, null, modelName, model);
            }
        }

        public TModel GetFormModel<TModel>(string modelName, FormObjectModel objModel = FormObjectModel.New) where TModel : class, new()
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                if (FormObjectModel.New == objModel)
                {
                    CollectData<TModel>(modelName);
                }
                return objectDict[modelName] as TModel;
            }
            else
            {
                switch (objModel)
                {
                    case FormObjectModel.Default:
                        return objects[0] as TModel;
                    case FormObjectModel.New:
                        CollectData<TModel>(modelName);
                        return objects[1] as TModel;
                    case FormObjectModel.Parent:
                        return objects[2] as TModel;
                    default:
                        return objects[0] as TModel;
                }
            }
        }
    }
}
