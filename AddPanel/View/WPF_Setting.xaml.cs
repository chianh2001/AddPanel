using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace AddPanel
{
    /// <summary>
    /// Interaction logic for WPF_Setting.xaml
    /// </summary>
    public partial class WPF_Setting : Window
    {
        private readonly UIDocument _uiDocument;
        private readonly Fam_DB _fam_db;
        private readonly UserSettingsManager _userSettingsManager;
        private UserSelections _userSelections;
        public WPF_Setting(UIDocument uiDocument)
        {
            InitializeComponent();
            _uiDocument = uiDocument;
            _fam_db = new Fam_DB(_uiDocument.Document);
            _userSettingsManager = new UserSettingsManager();
            LoadFamilies();
            LoadUserSelections();
        }

        private void LoadFamilies()
        {
            //Document doc = _uiDocument.Document;


            //List<string> doorFamilyNames = new FilteredElementCollector(doc)
            //    .OfClass(typeof(Family))
            //    .Cast<Family>()
            //    .Where(f => f.FamilyCategory.Name == "Doors") // Lọc các family thuộc loại cửa
            //    .Select(f => f.Name)
            //    .ToList();

            //var doorFamilyNames = _fam_db.GetDoorFamilyNames();
            //var structuralfoundationsFamilyNames = _fam_db.GetStructuralFoundationsFamilyNames();
            //var structuralcolumnsFamilyNames = _fam_db.GetStructureColumnsFamilyNames();
            //var tagdoorFamilyNames = _fam_db.GetTagDoorFamilyNames();

            cbbFamilyDoor.ItemsSource = _fam_db.GetDoorFamilyNames();
            cbbFamilyColumns.ItemsSource = _fam_db.GetStructuralFoundationsFamilyNames();
            cbbFamilyStructureColumns.ItemsSource = _fam_db.GetStructureColumnsFamilyNames();
            cbbDoorTag.ItemsSource = _fam_db.GetTagDoorFamilyNames();

        }

        private void LoadUserSelections()
        {
            _userSelections = _userSettingsManager.LoadUserSelections();

            cbbDoorTag.SelectedItem = _userSelections.SelectedFamily;
            cbbFamilyColumns.SelectedItem = _userSelections.SelectedFamily;
            cbbFamilyDoor.SelectedItem = _userSelections.SelectedFamily;
            cbbFamilyStructureColumns.SelectedItem = _userSelections.SelectedFamily;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            _userSelections.SelectedFamily = cbbDoorTag.SelectedItem as string;
            _userSelections.SelectedFamily = cbbFamilyColumns.SelectedItem as string;
            _userSelections.SelectedFamily = cbbFamilyDoor.SelectedItem as string;
            _userSelections.SelectedFamily = cbbFamilyStructureColumns.SelectedItem as string;

            _userSettingsManager.SaveUserSelections(_userSelections);
            MessageBox.Show("Selections saved!");
            Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
