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
            if (lstShifts.SelectedIndex > -1)
            {
                try
                {
                    var selectedShift = _workingShifts[lstShifts.SelectedIndex];
                    if (selectedShift != null)
                    {
                        txtShiftCode.Text = selectedShift.ShiftCode;
                        txtShiftName.Text = selectedShift.ShiftName;
                        txtShiftStart.Text = selectedShift.StartTime;
                        txtShiftEnd.Text = selectedShift.EndTime;
                        chkShiftActive.Checked = selectedShift.IsActive;
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                txtShiftCode.Text = "";
                txtShiftName.Text = "";
                txtShiftStart.Text = "";
                txtShiftEnd.Text = "";
                chkShiftActive.Checked = false;
            }
        }

        private void btnNewShift_Click(object sender, EventArgs e)
        {
            lstShifts.SelectedIndex = -1;
        }
        #endregion

        #region EXTERNAL TESTS
        private void btnNewExternalTest_Click(object sender, EventArgs e)
        {
            lstTests.SelectedIndex = -1;
        }

        private void btnTestSave_Click(object sender, EventArgs e)
        {
            try
            {
                ExternalTest selectedTest = lstTests.SelectedIndex > -1 ?
                    _externalTests[lstTests.SelectedIndex] : null;
                using (EyeBO bObj = new EyeBO())
                {
                    var bResult = bObj.SaveExternalTest(new ExternalTest
                    {
                        Id = selectedTest != null ? selectedTest.Id : 0,
                        IsActive = chkTestActive.Checked,
                        TestCode = txtTestCode.Text,
                        TestName = txtTestName.Text,
                    });

                    if (!bResult.Result)
                        MessageBox.Show(bResult.ErrorMessage, "Uyarı");
                    else
                        BindTests();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnTestDelete_Click(object sender, EventArgs e)
        {

        }

        private void lstTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTests.SelectedIndex > -1)
            {
                try
                {
                    var selectedTest = _externalTests[lstTests.SelectedIndex];
                    if (selectedTest != null)
                    {
                        txtTestCode.Text = selectedTest.TestCode;
                        txtTestName.Text = selectedTest.TestName;
                        chkTestActive.Checked = selectedTest.IsActive;
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                txtTestCode.Text = "";
                txtTestName.Text = "";
                chkTestActive.Checked = false;
            }
        }
        #endregion
    }
}
