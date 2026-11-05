using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Siemens.Engineering;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.Types;

namespace TiaFupAddIn
{
    /// <summary>
    /// Einstiegspunkt des Add-Ins. Wird vom TIA Portal geladen.
    /// </summary>
    public class AddInMain
    {
        private readonly TiaPortal _tiaPortal;

        public AddInMain(TiaPortal tiaPortal)
        {
            _tiaPortal = tiaPortal;
        }

        /// <summary>Exportiert die ausgewählten Bausteine als Quelldateien.</summary>
        public void ExportBlocksAsSources(IEnumerable<PlcBlock> blocks)
        {
            if (blocks == null) return;

            var blockList = blocks.ToList();
            if (blockList.Count == 0)
            {
                MessageBox.Show("Keine Bausteine ausgewählt.", "FUP Add-In");
                return;
            }

            using (var folderDialog = new FolderBrowserDialog { Description = "Zielordner für den Quellen-Export wählen" })
            {
                if (folderDialog.ShowDialog() != DialogResult.OK) return;

                var composition = blockList[0].BlockFolder.ProjectBlockFolderServiceProvider;
                var sourceGroup = GetSourceGroup(blockList[0]);

                foreach (var block in blockList)
                {
                    var fileName = Path.Combine(folderDialog.SelectedPath, $"{SanitizeFileName(block.Name)}.scl");
                    try
                    {
                        block.GenerateSourceFromBlock(sourceGroup);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Export von {block.Name} fehlgeschlagen: {ex.Message}", "FUP Add-In");
                    }
                }
            }
        }

        private static string SanitizeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }

        private static PlcSourceGroup GetSourceGroup(PlcBlock block)
        {
            // Quelldatei-Gruppe im Projekt suchen bzw. anlegen
            var softwareContainer = block.BlockFolder as PlcBlockUserGroup;
            var parent = softwareContainer;
            var sources = parent?.GetService<PlcSourceGroupProvider>();
            return sources?.SourceGroups.FirstOrDefault() ?? sources?.SourceGroups.CreateWithUniqueName("FupAddIn_Export");
        }
    }
}
