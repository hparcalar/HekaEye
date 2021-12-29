using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using HekaEye.Data;
using HekaEye.Helpers;
using HekaEye.Models;
using HekaEye.StudioModels;
using HekaEye.UseCase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HekaEye
{
    public partial class frmDefinitions : Form
    {
        ExternalTest[] _externalTests = new ExternalTest[0];
        WorkingShift[] _workingShifts = new WorkingShift[0];

        public frmDefinitions()
        {
            InitializeComponent();
        }

        private void frmHekaStudio_Load(object sender, EventArgs e)
        {
            BindAllModels();
        }

        private void BindAllModels()
        {
            BindShifts();
            BindTests();
        }

        private void BindShifts()
        {
            using (EyeBO bObj = new EyeBO())
            {
                _workingShifts = bObj.GetWorkingShifts();
                lstShifts.DataSource = _workingShifts;
                lstShifts.SelectedIndex = -1;
            }
        }

        private void BindTests()
        {
            using (EyeBO bObj = new EyeBO())
            {
                _externalTests = bObj.GetExternalTests();
                lstTests.DataSource = _externalTests;
                lstTests.SelectedIndex = -1;
            }
        }
       
        #region WINFORM EVENTS
       
        private void frmHekaStudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region SHIFT EVENTS
        private void btnShiftSave_Click(object sender, EventArgs e)
        {
            try
            {
                WorkingShift selectedShift = lstShifts.SelectedIndex > -1 ?
                    _workingShifts[lstShifts.SelectedIndex] : null;
                using (EyeBO bObj = new EyeBO())
                {
                    var bResult = bObj.SaveWorkingShift(new WorkingShift
                    {
                        Id = selectedShift != null ? selectedShift.Id : 0,
                        StartTime = txtShiftStart.Text,
                        EndTime = txtShiftEnd.Text,
                        IsActive = chkShiftActive.Checked,
                        ShiftCode = txtShiftCode.Text,
                        ShiftName = txtShiftName.Text,
                    });

                    if (!bResult.Result)
                        MessageBox.Show(bResult.ErrorMessage, "Uyarı");
                    else
                        BindShifts();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnShiftDelete_Click(object sender, EventArgs e)
        {

        }

        private void lstShifts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
