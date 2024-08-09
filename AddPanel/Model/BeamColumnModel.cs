using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPanel.Model
{
    public class BeamColumnModel
    {
        public FamilySymbol SelectedBeamType { get; set; }
        public FamilySymbol SelectedColumnType { get; set; }
        public Level SelectedBaseLevel { get; set; }
        public Level SelectedTopLevel { get; set; }
        public double ZOffset { get; set; }
        public double TopOffset { get; set; }
        public double BaseOffset { get; set; }
    }
}
