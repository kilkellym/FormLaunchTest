using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormLaunchTest
{
    internal static class Utils
    {
        public static bool ShowForm;
        internal static void Run(UIApplication uiapp)
        {
            Window1 curWin = new Window1();
            curWin.Width = 400;
            curWin.Height = 200;
            curWin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            curWin.ShowDialog();

            if(Utils.ShowForm)
            {
                IList<Reference> pickList = uiapp.ActiveUIDocument.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element);
                
                TaskDialog.Show("Test", "Running the command");
            }
            
            
        }
        internal static RibbonPanel CreateRibbonPanel(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel currentPanel = GetRibbonPanelByName(app, tabName, panelName);

            if (currentPanel == null)
                currentPanel = app.CreateRibbonPanel(tabName, panelName);

            return currentPanel;
        }

        internal static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tmpPanel in app.GetRibbonPanels(tabName))
            {
                if (tmpPanel.Name == panelName)
                    return tmpPanel;
            }

            return null;
        }
    }
}
