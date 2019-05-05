using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Selene.Forms.PartVolume;
using Selene.UIUtils;
using Selene.Model.SettingModel.Book.HFStyle;
using Selene.Model.Enums;
using Selene.BaseControl;
using Selene.Logical;
using Selene.Model.SettingModel.Book;
using Selene.Model.SettingModel.Factory;

namespace Selene.Forms.Setting.HFStyle
{
    public partial class HeaderFooterStyleCtrl : BasePropertyGridSettingCtrl
    {
        private CommonSettingBLL commonSettingBLL;
        private HeaderFooterStyleSetting currentHfsSetting;
        public HeaderFooterStyleCtrl()
        {
            InitializeComponent();

            commonSettingBLL = new CommonSettingBLL();
        }

        public override bool SaveEvent()
        {
            var hfStyle = pgMain.Tag.ToString();

            if (hfStyle.Equals(HeaderFooterStyle.Tradition.ToString()))
            {
                currentHfsSetting = PropertyGridUtil.GridObject2Model<HFStyleTradition>(pgMain.SelectedObject);
            }
            else
            {
                currentHfsSetting = PropertyGridUtil.GridObject2Model<HFStyleModern>(pgMain.SelectedObject);
            }

            return commonSettingBLL.SaveHeaderFooterStyleSetting(currentHfsSetting);
        }

        public override bool CloseEvent()
        {
            return true;
        }

        public override void CtrlLoad()
        {
            var hfsSetting = commonSettingBLL.GetHeaderFooterStyleSetting();
            currentHfsSetting = hfsSetting;
            pgMain.Tag = hfsSetting.HFStyle;

            if (hfsSetting.HFStyle == HeaderFooterStyle.Tradition)
            {
                this.pgMain.SelectedObject = PropertyGridUtil.GetObject<HFStyleTradition>(hfsSetting as HFStyleTradition);
            }
            else
            {
                this.pgMain.SelectedObject = PropertyGridUtil.GetObject<HFStyleModern>(hfsSetting as HFStyleModern);
            }
        }

        private void pgMain_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if ("HFStyle".Equals(e.ChangedItem.PropertyDescriptor.Name))
            {
                pgMain.Tag = e.ChangedItem.Value;
                if (e.ChangedItem.Value.Equals(HeaderFooterStyle.Modern.ToString()))
                {
                    if (currentHfsSetting.HFStyle == HeaderFooterStyle.Modern)
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<HFStyleModern>(currentHfsSetting as HFStyleModern);
                    }
                    else
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<HFStyleModern>(HeaderFooterStyleSettingFactory.DefaultHFStyleModern());
                    }
                }
                else
                {
                    if (currentHfsSetting.HFStyle == HeaderFooterStyle.Tradition)
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<HFStyleTradition>(currentHfsSetting as HFStyleTradition);
                    }
                    else
                    {
                        pgMain.SelectedObject = PropertyGridUtil.GetObject<HFStyleTradition>(HeaderFooterStyleSettingFactory.DefaultHFStyleTradition());
                    }
                }

            }
        }
    }
}
