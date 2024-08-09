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
using AddPanel.ViewModel;

namespace AddPanel
{
    /// <summary>
    /// Interaction logic for WPF_Setting.xaml
    /// </summary>
    public partial class WPF_Create : Window
    {
        //// Các thuộc tính công khai để lưu trữ giá trị được chọn từ WPF
        //public FamilySymbol SelectedBeamType { get; private set; }
        //public ReferencePlane SelectedReferencePlane { get; private set; }
        //public double ZOffset { get; private set; }
        //public FamilySymbol SelectedColumnType { get; private set; }
        //public Level SelectedTopLevel { get; private set; }
        //public double TopOffset { get; private set; }
        //public Level SelectedBaseLevel { get; private set; }
        //public double BaseOffset { get; private set; }

        //private readonly UIDocument _uidoc;
        //private readonly Document _doc;

        //public WPF_Create(UIDocument uidoc)
        //{
        //    InitializeComponent();
        //    _uidoc = uidoc;
        //    _doc = uidoc.Document;

        //    // Populate the combo boxes with data from the document
        //    PopulateComboBoxes();
        //}

        //private void PopulateComboBoxes()
        //{
        //    // Populate Reference Plane ComboBox
        //    var refPlanes = new FilteredElementCollector(_doc)
        //                        .OfClass(typeof(Level))
        //                        .Cast<Level>()
        //                        .ToList();
        //    cbReferencePlane.ItemsSource = refPlanes;
        //    cbReferencePlane.DisplayMemberPath = "Name";

        //    // Populate Beam Type ComboBox
        //    var beamTypes = new FilteredElementCollector(_doc)
        //                        .OfClass(typeof(FamilySymbol))
        //                        .OfCategory(BuiltInCategory.OST_StructuralFraming)
        //                        .Cast<FamilySymbol>()
        //                        .ToList();
        //    cbBeamType.ItemsSource = beamTypes;
        //    cbBeamType.DisplayMemberPath = "Name";

        //    // Populate Level ComboBoxes
        //    var levels = new FilteredElementCollector(_doc)
        //                     .OfClass(typeof(Level))
        //                     .Cast<Level>()
        //                     .ToList();
        //    cbTopLevel.ItemsSource = levels;
        //    cbBaseLevel.ItemsSource = levels;
        //    cbTopLevel.DisplayMemberPath = "Name";
        //    cbBaseLevel.DisplayMemberPath = "Name";

        //    // Populate Column Type ComboBox
        //    var columnTypes = new FilteredElementCollector(_doc)
        //                        .OfClass(typeof(FamilySymbol))
        //                        .OfCategory(BuiltInCategory.OST_StructuralColumns)
        //                        .Cast<FamilySymbol>()
        //                        .ToList();
        //    cbColumnType.ItemsSource = columnTypes;
        //    cbColumnType.DisplayMemberPath = "Name";
        //}

        //private void BtnOK_Click(object sender, RoutedEventArgs e)
        //{
        //    // Lấy các giá trị từ WPF và gán vào các thuộc tính
        //    SelectedBaseLevel = cbReferencePlane.SelectedItem as Level;
        //    ZOffset = double.Parse(tbZOffset.Text);
        //    SelectedBeamType = cbBeamType.SelectedItem as FamilySymbol;
        //    SelectedTopLevel = cbTopLevel.SelectedItem as Level;
        //    TopOffset = double.Parse(tbTopOffset.Text);
        //    SelectedBaseLevel = cbBaseLevel.SelectedItem as Level;
        //    BaseOffset = double.Parse(tbBaseOffset.Text);
        //    SelectedColumnType = cbColumnType.SelectedItem as FamilySymbol;

        //    DialogResult = true;
        //    Close();
        //}

        //private void BtnCancel_Click(object sender, RoutedEventArgs e)
        //{
        //    DialogResult = false;
        //    Close();
        //}

        private BeamColumnViewModel viewModel;

        public WPF_Create(UIDocument uidoc)
        {
            InitializeComponent();
            viewModel = new BeamColumnViewModel(uidoc);
            DataContext = viewModel;

            // Bind UI elements to ViewModel properties
            // e.g., combo boxes for beam and column types, levels, etc.
        }

        private void CreateBeamAndColumn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateBeamAndColumn();
        }
    }
}
