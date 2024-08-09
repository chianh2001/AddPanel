using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPanel.Commands
{
    internal class cm_tagwall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            WPF_Setting wpfsetting = new WPF_Setting(commandData.Application.ActiveUIDocument);
            wpfsetting.ShowDialog();
            return Result.Succeeded;
        }
    }
}
