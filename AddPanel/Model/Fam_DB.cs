using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPanel
{
    public class Fam_DB
    {
        private readonly Document _document;

        public Fam_DB (Document document)
        {
            _document = document;
        }

        public List<string> GetDoorFamilyNames()
        {
            return new FilteredElementCollector(_document)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .Where(f => f.FamilyCategory.Name == "Doors") // Lọc các family thuộc loại cửa
                .Select(f => f.Name)
                .ToList();
        }

        public List<string> GetStructureColumnsFamilyNames()
        {
            return new FilteredElementCollector(_document)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .Where(f => f.FamilyCategory.Name == "Structural Columns") // Lọc các family thuộc loại cửa
                .Select(f => f.Name)
                .ToList();
        }

        public List<string> GetStructuralFoundationsFamilyNames()
        {
            return new FilteredElementCollector(_document)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .Where(f => f.FamilyCategory.Name == "Structural Foundations") // Lọc các family thuộc loại cửa
                .Select(f => f.Name)
                .ToList();
        }

        public List<string> GetTagDoorFamilyNames()
        {
            return new FilteredElementCollector(_document)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .Where(f => f.FamilyCategory.Name == "Door Tags") // Lọc các family thuộc loại cửa
                .Select(f => f.Name)
                .ToList();
        }
    }
}
