using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Selene.BaseControl;
using Selene.UIUtils;
using Selene.Model.SettingModel.Book.HFStyle;
using Selene.Model.SettingModel.Book;
using Selene.Logical;
using Selene.Model.Enums;
using Selene.Model.SettingModel.Factory;

namespace Selene.Forms.Setting.LMStyle
{
    public partial class LineageMapStyleCtrl : BasePropertyGridSettingCtrl
    {
        private CommonSettingBLL commonSettingBLL;
        private LineageMapStyleSetting currentLmsSetting;
        public LineageMapStyleCtrl()
        {
            InitializeComponent();

            commonSettingBLL = new CommonSettingBLL();
        }

        public override bool SaveEvent()
        {
            var lmStyle = pgMain.Tag.ToString();

            if (lmStyle.Equals(LineageMapStyle.MessengerWire.ToString()))
            {
                currentLmsSetting = PropertyGridUtil.GridObject2Model<MessengerWireLineageMapStyleSetting>(pgMain.SelectedObject);
            }
            else
            {
                currentLmsSetting = PropertyGridUtil.GridObject2Model<BoxLineageMapStyleSetting>(pgMain.SelectedObject);
            }

            return commonSettingBLL.SaveLineageMapStyleSetting(currentLmsSetting);
        }

        public override void CtrlLoad()
        {
            var lmsSetting = commonSettingBLL.GetLineageMapStyleSetting();
            currentLmsSetting = lmsSetting;
            pgMain.Tag = lmsSetting.LMStyle;

            if (lmsSetting.LMStyle == LineageMapStyle.MessengerWire)
            {
                this.pgMain.SelectedObject = PropertyGridUtil.GetObject<MessengerWireLineageMapStyleSetting>(lmsSetting as MessengerWireLineageMapStyleSetting);
            }
            else
            {
                this.pgMain.SelectedObject = PropertyGridUtil.GetObject<BoxLineageMapStyleSetting>(lmsSetting as BoxLineageMapStyleSetting);
            }

        }

        private void pgMain_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if ("LMStyle".Equals(e.ChangedItem.PropertyDescriptor.Name))
            {
                pgMain.Tag = e.ChangedItem.Value;
                if (e.ChangedItem.Value.Equals(LineageMapStyle.MessengerWire.ToString()))
                {
                    if (currentLmsSetting.LMStyle == LineageMapStyle.MessengerWire)
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<MessengerWireLineageMapStyleSetting>(currentLmsSetting as MessengerWireLineageMapStyleSetting);
                    }
                    else
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<MessengerWireLineageMapStyleSetting>(LineageMapStyleSettingFactory.DefaultMessengerWireValue());
                    }
                }
                else
                {
                    if (currentLmsSetting.LMStyle == LineageMapStyle.Box)
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<BoxLineageMapStyleSetting>(currentLmsSetting as BoxLineageMapStyleSetting);
                    }
                    else
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<BoxLineageMapStyleSetting>(LineageMapStyleSettingFactory.DefaultBoxValue());
                    }
                }

            }
        }
    }
}
