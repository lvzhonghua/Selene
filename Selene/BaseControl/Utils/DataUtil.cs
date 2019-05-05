using Selene.BaseControl.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.BaseControl.Utils
{
    public class DataUtil
    {
        public static void GetAllControl(Form form, Control ctrl, List<Control> allCtrls)
        {
            if (form == null)
            {
                foreach (Control c in ctrl.Controls)
                {
                    allCtrls.Add(c);
                    // 处理c
                    if (c.HasChildren)
                    {
                        GetAllControl(null, c, allCtrls);  // 递归
                    }
                }
            }
            else
            {
                foreach (Control c in form.Controls)
                {
                    allCtrls.Add(c);
                    // 处理c
                    if (c.HasChildren)
                    {
                        GetAllControl(null, c, allCtrls);  // 递归
                    }
                }
            }
        }

        public static TModel CollectData<TModel>(Form form, Control ctrl, string modelName, TModel model) where TModel : class,new()
        {
            TModel newModel = ModelToModel<TModel>(model);

            if (newModel == null)
            {
                newModel = new TModel();
            }

            List<Control> thisCtrls = GetAllCtrls(form, ctrl, modelName);

            foreach (Control item in thisCtrls)
            {
                if (item.GetType().GetInterface("IDataControl") != null)
                {
                    var columnName = ((IDataControl)item).PropertyName;
                    if (string.IsNullOrEmpty(columnName))
                    {
                        continue;
                    }
                    string value = item.Text;
                    if (typeof(ListControl).IsAssignableFrom(item.GetType()))
                    {
                        var selValue = ((ListControl)item).SelectedValue;
                        value = selValue == null ? "" : selValue.ToString();
                    }
                    else if (typeof(CheckBox).IsAssignableFrom(item.GetType()))
                    {
                        value = ((CheckBox)item).Checked.ToString();
                    }

                    Type modelType = typeof(TModel);
                    PropertyInfo propertyInfo = modelType.GetProperty(columnName);
                    if (propertyInfo == null)
                    {
                        continue;
                    }
                    Type columnType = propertyInfo.PropertyType;
                    if (columnType == typeof(int?) || columnType == typeof(int))
                    {
                        if (string.IsNullOrEmpty(value))
                        {
                            value = "0";
                        }
                        propertyInfo.SetValue(newModel, int.Parse(value), null);
                    }
                    else if (columnType == typeof(bool?) || columnType == typeof(bool))
                    {
                        propertyInfo.SetValue(newModel, bool.Parse(value), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(newModel, value, null);
                    }
                }
            }
            return newModel;
        }

        private static TModel ModelToModel<TModel>(TModel model) where TModel : class,new()
        {
            if (model == null) { return null; }
            Type tmodel = typeof(TModel);

            TModel newModel = new TModel();

            foreach (var item in tmodel.GetProperties())
            {
                if (item.CanWrite)
                {
                    item.SetValue(newModel, item.GetValue(model, null), null);
                }
            }
            return newModel;
        }

        public static List<Control> GetAllCtrls(Form form, Control ctrl)
        {
            return GetAllCtrls(form, ctrl, "");
        }

        public static List<Control> GetAllCtrls(Form form, Control ctrl, string modelName)
        {
            List<Control> ctrls = new List<Control>();

            GetAllControl(form, ctrl, ctrls);

            if (string.IsNullOrEmpty(modelName))
            {
                return ctrls;
            }
            return ctrls.Where(c => c is IDataControl && modelName.Equals((c as IDataControl).ModelName)).ToList();
        }

        public static void SetDataModel<TModel>(Form form, Control ctrl, string modelName, TModel model)
        {
            List<Control> thisCtrls = GetAllCtrls(form, ctrl, modelName);

            foreach (Control item in thisCtrls)
            {
                if (item.GetType().GetInterface("IDataControl") != null)
                {
                    var columnName = ((IDataControl)item).PropertyName;
                    if (string.IsNullOrEmpty(columnName))
                    {
                        continue;
                    }

                    Type modelType = typeof(TModel);
                    PropertyInfo propertyInfo = modelType.GetProperty(columnName);

                    var value = propertyInfo.GetValue(model, null);
                    if (value == null) { continue; }

                    if (typeof(CheckBox).IsAssignableFrom(item.GetType()))
                    {
                        ((CheckBox)item).Checked = "true".Equals(value.ToString().ToLower());
                    }
                    else if (typeof(ListBox).IsAssignableFrom(item.GetType()))
                    {
                        ((ListBox)item).SelectedValue = value.ToString();
                    }
                    else if (typeof(ComboBox).IsAssignableFrom(item.GetType()))
                    {
                        ((ComboBox)item).SelectedValue = value.ToString();
                    }
                    else
                    {
                        item.Text = value.ToString();
                    }
                }
            }
        }
    }
}
