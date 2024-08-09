using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;

namespace AddPanel
{
    [Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class cm_createwall : IExternalCommand
    {
        //public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        //{
        //    UIDocument uidoc = commandData.Application.ActiveUIDocument;
        //    Document doc = uidoc.Document;

        //    string excelFilePath = @"C:\Path\To\Your\File.xlsx";

        //    // Đọc dữ liệu từ file Excel
        //    DataSet dataSet = ReadExcelFile(excelFilePath);

        //    // Tạo tường từ dữ liệu
        //    using (Transaction trans = new Transaction(doc, "Create Walls"))
        //    {
        //        trans.Start();

        //        foreach (DataRow row in dataSet.Tables[0].Rows)
        //        {
        //            string wallTypeName = row["WallTypeName"].ToString();
        //            double wallHeight = Convert.ToDouble(row["Height"]);
        //            double wallLength = Convert.ToDouble(row["Length"]);

        //            // Tìm hoặc tạo WallType
        //            WallType wallType = FindOrCreateWallType(doc, wallTypeName);

        //            // Tạo tường
        //            CreateWall(doc, wallType, wallHeight, wallLength);
        //        }

        //        trans.Commit();
        //    }

        //    return Result.Succeeded;
        //}

        //private DataSet ReadExcelFile(string filePath)
        //{
        //    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            var result = reader.AsDataSet();
        //            return result;
        //        }
        //    }
        //}

        //private WallType FindOrCreateWallType(Document doc, string wallTypeName)
        //{
        //    // Tìm WallType
        //    WallType wallType = new FilteredElementCollector(doc)
        //        .OfClass(typeof(WallType))
        //        .Cast<WallType>()
        //        .FirstOrDefault(wt => wt.Name == wallTypeName);

        //    if (wallType == null)
        //    {
        //        // Tạo mới nếu không tìm thấy
        //        wallType = WallType.Create(doc, new ElementId(BuiltInCategory.OST_Walls));
        //        wallType.Name = wallTypeName;
        //    }

        //    return wallType;
        //}

        //private void CreateWall(Document doc, WallType wallType, double height, double length)
        //{
        //    // Tạo tường
        //    Line wallLine = Line.CreateBound(new XYZ(0, 0, 0), new XYZ(length, 0, 0));
        //    Wall wall = Wall.Create(doc, wallLine, wallType.Id, Level.Create(doc, 0).Id, height, 0, false, false);
        //}

        // The main Execute method (inherited from IExternalCommand) must be public
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
            ref string message, ElementSet elements)
        {
            return Result.Succeeded;
        }
    }
}
