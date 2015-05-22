using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.ReportOutput.OutputFormatter
{
    class TxtOutputFormat
    {


        string activeDir = Program.state.panelOutputSelect_OutputPath.Substring(0, Program.state.panelOutputSelect_OutputPath.LastIndexOf("\\")) + "\\" + Program.state.ProjectName + "-Data" + DateTime.Now.ToString("HHmmss_ddMMyy");

        public void ExportPluginOutput()
        {
            Creating_Folder();
            Txtouput();
        }

        private void Creating_Folder()
        {
            string newPath = System.IO.Path.Combine(activeDir, "GROUP_by_HOST");
            System.IO.Directory.CreateDirectory(newPath);
            newPath = System.IO.Path.Combine(activeDir, "GROUP_by_PLUGINID");
            System.IO.Directory.CreateDirectory(newPath);



        }
        private void Txtouput()
        {
            Program.state.panelRecordEdit_recordDatabaser.GetPluginOutputToTxtGroupByPluginID(activeDir + "\\GROUP_by_PLUGINID\\");
            Program.state.panelRecordEdit_recordDatabaser.GetPluginOutputToTxtGroupByHost(activeDir + "\\GROUP_by_HOST\\");
 
        }

    }
}
