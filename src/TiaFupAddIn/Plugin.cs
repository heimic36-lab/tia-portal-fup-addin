using Siemens.Engineering.AddIn;
using Siemens.Engineering.AddIn.Menu;

namespace TiaFupAddIn
{
    /// <summary>
    /// Registriert die Kontextmenü-Einträge im TIA Portal.
    /// </summary>
    public class Plugin : MenuAddIn
    {
        public override string Name => "TIA FUP Add-In";

        public Plugin() : base() { }

        public override void BuildMenuItems(MenuAddInProvider menuAddInProvider)
        {
            menuAddInProvider.CreateMenuItems<PlcBlock>()
                .AddItem("Export as source", (context) =>
                {
                    new AddInMain(context.TiaPortal).ExportBlocksAsSources(context.SelectedItems);
                });
        }
    }
}
