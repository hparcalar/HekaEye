using HekaEye.UseCase.VisionProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HekaEye.SkyStudio.PartialControls
{
    public partial class StreamToolItem : UserControl
    {
        public StreamToolItem()
        {
            InitializeComponent();
        }

        public delegate void ToolItemClickedHandler(object sender);
        public event ToolItemClickedHandler OnToolItemClicked;

        public delegate void ToolItemDeleteHandler(int processStepId);
        public event ToolItemDeleteHandler OnToolItemDeleted;

        private void StreamToolItem_Click(object sender, EventArgs e)
        {
            OnToolItemClicked?.Invoke(this);
        }

        private void BindData()
        {
            if (this.Tag != null)
            {
                var proc = (IVisionProcess)this.Tag;
                lblProcName.Text = proc.ProcessType.ToString();
            }
        }

        private void StreamToolItem_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnDeleteTool_Click(object sender, EventArgs e)
        {
            OnToolItemDeleted?.Invoke(((IVisionProcess)this.Tag).ProcessId);
        }
    }
}
