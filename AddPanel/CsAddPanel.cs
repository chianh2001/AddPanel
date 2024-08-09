using System;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace AddPanel
{
    /// <remarks>
    /// This application's main class. The class must be Public.
    /// </remarks>
    public class CsAddPanel : IExternalApplication
    {
        // Both OnStartup and OnShutdown must be implemented as public method
        public Result OnStartup(UIControlledApplication application)
        {
            // Create Tab
            string nameTab = "AddPanel Check";
            application.CreateRibbonTab(nameTab);

            // Add a new ribbon panel
            RibbonPanel rbp_setting = application.CreateRibbonPanel(nameTab, "Setting");
            RibbonPanel rbp_wallutils = application.CreateRibbonPanel(nameTab, "Wall Utils");
            RibbonPanel rbp_doorutils = application.CreateRibbonPanel(nameTab, "Door Utils");
            RibbonPanel rbp_roomutils = application.CreateRibbonPanel(nameTab, "Room Utils");
            RibbonPanel rbp_create = application.CreateRibbonPanel(nameTab, "Create");

            // Create Button
            PushButtonData btn_setting = createButton("cmd_setting", "Settings", "settings.png", "Setting system family, color for Jasty addin.", "", "cm_setting");
            PushButtonData btn_createwall = createButton("cmd_createwall", "Create Wall", "createwall.png", "Auto create wall type with specific name.", "", "cm_createwall");
            PushButtonData btn_walltag = createButton("cmd_walltag", "Tag Wall", "tagwall.png", "Tag wall with specific position and tag type.", "", "cm_trienkhaithep");
            PushButtonData btn_autotagall = createButton("cmd_autotagall", "Auto Tag All", "autotagall.png", "Automatically tag all wall in current view.", "", "cm_matcat");
            PushButtonData btn_checkalltag = createButton("cmd_checkalltag", "Check All Tag", "checkalltag.png", "Check the wrong tag in current view.", "", "cm_xuatthuyetminh");
            PushButtonData btn_verifytag = createButton("cmd_verifytagn", "Verify Tag", "verifytag.png", "Automatically correct the wrong tag.", "", "");
            PushButtonData btn_autorename = createButton("cmd_autorename", "Auto Rename", "autorename.png", "Auto rename door type with specific parameters.", "", "");
            PushButtonData btn_defineposition = createButton("cmd_defineposition", "Define Position", "defineposition.png", "Define the room that door is belong to.", "", "");
            PushButtonData btn_updateroomarea = createButton("cmd_updateroomarea", "Update Room Area", "updateroomarea.png", "Auto update area from area plan to room plane.", "", "");
            PushButtonData btn_create = createButton("cmd_create", "Create Beam&Column", "settings.png", "Setting system family, color for Jasty addin.", "", "cm_create");


            rbp_setting.AddItem(btn_setting);
            rbp_wallutils.AddItem(btn_createwall);
            rbp_wallutils.AddItem(btn_walltag);
            rbp_wallutils.AddItem(btn_autotagall);
            rbp_wallutils.AddItem(btn_checkalltag);
            rbp_doorutils.AddItem(btn_verifytag);
            rbp_doorutils.AddItem(btn_autorename);
            rbp_doorutils.AddItem(btn_defineposition);
            rbp_roomutils.AddItem(btn_updateroomarea);
            rbp_create.AddItem(btn_create);


            //// a) tool-tip
            //btn_setting.ToolTip = "Setting system family, color for Jasty addin.";
            //btn_createwall.ToolTip = "Auto create wall type with specific name.";
            //btn_walltag.ToolTip = "Tag wall with specific position and tag type.";
            //btn_autotagall.ToolTip = "Automatically tag all wall in current view.";
            //btn_checkalltag.ToolTip = "Check the wrong tag in current view.";
            //btn_verifytag.ToolTip = "Automatically correct the wrong tag.";
            //btn_autorename.ToolTip = "Auto rename door type with specific parameters.";
            //btn_defineposition.ToolTip = "Define the room that door is belong to.";
            //btn_updateroomarea.ToolTip = "Auto update area from area plan to room plane.";
            
            btn_setting.LongDescription = "dsaffffffffsdafewfaddsaf";

            return Result.Succeeded;
        }

        public PushButtonData createButton(string btnName, string btnText, string path_image, string text_Tooltip, string url_Help, string cls_name)
        {
            //Tạo ribbon button
            string path = Assembly.GetExecutingAssembly().Location;
            PushButtonData button = new PushButtonData(btnName, btnText, path, "AddPanel." + cls_name);
            //addTooltip
            button.ToolTip = text_Tooltip;

            //add Help


            //Set icon cho button
            button.LargeImage = Class1.GetImage(path_image,32,32);
            return button;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}