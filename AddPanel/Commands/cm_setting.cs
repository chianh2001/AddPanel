﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPanel
{
    [Transaction(TransactionMode.Manual)]
    internal class cm_setting : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            WPF_Setting wpfsetting = new WPF_Setting(commandData.Application.ActiveUIDocument);
            wpfsetting.ShowDialog();
            return Result.Succeeded;
        }
    }
}
