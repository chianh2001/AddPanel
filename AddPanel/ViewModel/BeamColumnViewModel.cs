using AddPanel.Model;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPanel.ViewModel
{
    public class BeamColumnViewModel
    {
        private BeamColumnModel model;
        private UIDocument uidoc;
        private Document doc;

        public BeamColumnViewModel(UIDocument uidoc)
        {
            this.uidoc = uidoc;
            this.doc = uidoc.Document;
            model = new BeamColumnModel();
        }

        public BeamColumnModel Model => model;

        public void CreateBeamAndColumn()
        {
            using (Transaction trans = new Transaction(doc, "Create Beam and Column"))
            {
                trans.Start();

                if (!model.SelectedBeamType.IsActive)
                {
                    model.SelectedBeamType.Activate();
                    doc.Regenerate();
                }

                if (!model.SelectedColumnType.IsActive)
                {
                    model.SelectedColumnType.Activate();
                    doc.Regenerate();
                }

                XYZ point = uidoc.Selection.PickPoint("Pick a point to place beam and column");

                FamilyInstance column = doc.Create.NewFamilyInstance(
                    point,
                    model.SelectedColumnType,
                    model.SelectedBaseLevel,
                    StructuralType.Column);

                column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_PARAM).Set(model.SelectedTopLevel.Id);
                column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(model.TopOffset / 304.8);
                column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).Set(model.BaseOffset / 304.8);

                XYZ beamEndPoint = new XYZ(point.X + 10, point.Y, point.Z);
                Line beamLine = Line.CreateBound(point, beamEndPoint);

                FamilyInstance beam = doc.Create.NewFamilyInstance(
                                        beamLine,
                                        model.SelectedBeamType,
                                        model.SelectedBaseLevel,
                                        StructuralType.Beam);

                Parameter topElevationParam = beam.get_Parameter(BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP);
                if (topElevationParam != null && !topElevationParam.IsReadOnly)
                {
                    topElevationParam.Set(model.ZOffset / 304.8);
                }
                else
                {
                    LocationCurve beamCurve = beam.Location as LocationCurve;
                    if (beamCurve != null)
                    {
                        XYZ translationVector = new XYZ(0, 0, model.ZOffset / 304.8);
                        beamCurve.Move(translationVector);
                    }
                }

                trans.Commit();
            }
        }
    }
}
