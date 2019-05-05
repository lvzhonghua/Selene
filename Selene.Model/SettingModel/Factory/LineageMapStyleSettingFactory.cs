using Selene.Model.Enums;
using Selene.Model.Enums.Lineage;
using Selene.Model.SettingModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel.Factory
{
    public class LineageMapStyleSettingFactory
    {

        public static LineageMapStyleSetting DefaultLineageMapStyleSetting()
        {
            return DefaultMessengerWireValue();
        }

        public static MessengerWireLineageMapStyleSetting DefaultMessengerWireValue()
        {
            return new MessengerWireLineageMapStyleSetting()
            {
                AnnotationFont = "宋体,12",
                BranchFont = "宋体,12",
                CharacterSpace = 100,
                RowSpace = 100,
                ClansmanName = "宋体,12",
                ClansmanNameToBorderSpace = 0.8,
                ClansmanNameToPrevGenealogyNoteSpace = 0.8,
                ContentFont = "宋体,12",
                ContentToBorderSpace = 0.8,
                ContentToClansmanName = 0.8,
                LineageNoteCharacterSpace = 0.8,
                LineageNoteFont = "宋体,12",
                LineageNoteRowSpace = 0.8,
                LinellaeThickness = LinellaeThicknessStyle.Thick,
                LMStyle = LineageMapStyle.MessengerWire,
                TitleFont = "宋体,12",
                UpTurnDownJoinFont = "宋体,12",
                WorldNumberFont = "宋体,12"
            };
        }

        public static BoxLineageMapStyleSetting DefaultBoxValue()
        {
            return new BoxLineageMapStyleSetting()
            {
                AnnotationFont = "宋体,12",
                ClansmanName = "宋体,12",
                LinellaeThickness = LinellaeThicknessStyle.Thick,
                LMStyle = LineageMapStyle.Box,
                TitleFont = "宋体,12",
                WorldNumberFont = "宋体,12",
                LineageNoteFont = "宋体,12",
                PageFont = "宋体,12"
            };
        }
    }
}
