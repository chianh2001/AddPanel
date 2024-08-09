using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI.Selection;

namespace AddPanel
{
    [Transaction(TransactionMode.Manual)]
    public class cm_create : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //UIDocument uidoc = commandData.Application.ActiveUIDocument;
            //Document doc = uidoc.Document;

            //// Hiển thị form WPF để người dùng chọn các thông số
            //WPF_Create window = new WPF_Create(uidoc);
            //if (window.ShowDialog() == true)
            //{
            //    using (Transaction trans = new Transaction(doc, "Create Beam and Column"))
            //    {
            //        trans.Start();

            //        // Kích hoạt FamilySymbol cho dầm và cột nếu chưa được kích hoạt
            //        if (!window.SelectedBeamType.IsActive)
            //        {
            //            window.SelectedBeamType.Activate();
            //            doc.Regenerate(); // Regenerate document after activating the symbol
            //        }

            //        if (!window.SelectedColumnType.IsActive)
            //        {
            //            window.SelectedColumnType.Activate();
            //            doc.Regenerate(); // Regenerate document after activating the symbol
            //        }

            //        // Lấy điểm click từ người dùng
            //        XYZ point = uidoc.Selection.PickPoint("Pick a point to place beam and column");

            //        // Tạo cột
            //        FamilyInstance column = doc.Create.NewFamilyInstance(
            //            point,
            //            window.SelectedColumnType,
            //            window.SelectedBaseLevel,
            //            StructuralType.Column);

            //        // Thiết lập Top Level cho cột (sử dụng phương thức Create mới hoặc trực tiếp qua API)
            //        column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_PARAM).Set(window.SelectedTopLevel.Id);
            //        column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(window.TopOffset/304.8);
            //        column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).Set(window.BaseOffset/304.8);

            //        // Tạo ra một điểm kết thúc cho dầm
            //        XYZ beamEndPoint = new XYZ(point.X + 10, point.Y, point.Z);

            //        // Tạo ra đường dẫn (Line) cho dầm
            //        Line beamLine = Line.CreateBound(point, beamEndPoint);

            //        // Tạo dầm với Level đã chọn
            //        FamilyInstance beam = doc.Create.NewFamilyInstance(
            //                              beamLine,
            //                              window.SelectedBeamType,
            //                              window.SelectedBaseLevel,  // Level để đặt dầm
            //                              StructuralType.Beam);

            //        Parameter topElevationParam = beam.get_Parameter(BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP);
            //        if (topElevationParam != null && !topElevationParam.IsReadOnly)
            //        {
            //            topElevationParam.Set(window.ZOffset / 304.8);
            //        }
            //        else
            //        {
            //            // Sử dụng LocationCurve để di chuyển dầm
            //            LocationCurve beamCurve = beam.Location as LocationCurve;
            //            if (beamCurve != null)
            //            {
            //                XYZ translationVector = new XYZ(0, 0, window.ZOffset / 304.8);
            //                beamCurve.Move(translationVector);
            //            }
            //        }
            //        //// Đặt chiều cao (z-offset) của dầm dựa trên Level
            //        //beam.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM).Set(window.SelectedBaseLevel.Id);
            //        //beam.get_Parameter(BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP).Set(window.ZOffset);

            //        trans.Commit();
            //    }
            //}

            //return Result.Succeeded;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            WPF_Create window = new WPF_Create(uidoc);

            if (window.ShowDialog() == true)
            {
                return Result.Succeeded;
            }

            return Result.Failed;
        }
    }
}
