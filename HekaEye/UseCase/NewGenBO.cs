using HekaEye.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HekaEye.Models;
using HekaEye.StudioModels;
using System.Data.Entity;

namespace HekaEye.UseCase
{
    public class NewGenBO : IDisposable
    {
        public IList<HkProgramModel> GetProgramList()
        {
            List<HkProgramModel> data = new List<HkProgramModel>();

            using (EyeContext ctx = new EyeContext())
            {
                data = ctx.HkProgram.Select(d => new HkProgramModel
                {
                    Id = d.Id,
                    AutoTriggerInterval = d.AutoTriggerInterval ?? 0,
                    CameraName = d.CameraName,
                    ProgramName = d.ProgramName,
                    RunningStatus = d.RunningStatus,
                    TriggerMode = d.TriggerMode,
                }).ToList();
            }

            return data;
        }

        public HkProgramModel GetProgram(int programId)
        {
            HkProgramModel data = new HkProgramModel();

            using (EyeContext ctx = new EyeContext())
            {
                data = ctx.HkProgram.Where(d => d.Id == programId)
                    .Select(d => new HkProgramModel
                    {
                        Id = d.Id,
                        AutoTriggerInterval = d.AutoTriggerInterval ?? 0,
                        CameraName = d.CameraName,
                        ProgramName = d.ProgramName,
                        RunningStatus = d.RunningStatus,
                        TriggerMode = d.TriggerMode,
                    }).FirstOrDefault();

                if (data != null)
                {
                   data.Tools = ctx.HkTool.Where(d => d.ProgramId == programId)
                       .Select(d => new HkToolModel
                       {
                           Id = d.Id,
                           ProgramId = d.ProgramId,
                           ToolName = d.ToolName,
                           ToolOrder = d.ToolOrder,
                           ToolSettings = d.ToolSettings,
                           ToolType = d.ToolType,
                       }).ToList();
                }
                else
                {
                    data = new HkProgramModel
                    {
                        Id = 0,
                        ProgramName = "Program 000",
                        Tools = new List<HkToolModel>(),
                    };
                }
            }

            return data;
        }

        public BusinessResult SaveProgram(HkProgramModel model)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext ctx = new EyeContext())
                {
                    var dbProg = ctx.HkProgram.FirstOrDefault(d => d.Id == model.Id);
                    if (dbProg == null)
                    {
                        dbProg = new HkProgram();
                        ctx.HkProgram.Add(dbProg);
                    }

                    // map props to program
                    dbProg.AutoTriggerInterval = model.AutoTriggerInterval;
                    dbProg.CameraName = model.CameraName;
                    dbProg.ProgramName = model.ProgramName;
                    dbProg.RunningStatus = model.RunningStatus;
                    dbProg.TriggerMode = model.TriggerMode;

                    // remove deleted tools
                    var oldTools = ctx.HkTool.Where(d => d.ProgramId == model.Id).ToArray();
                    var removedTools = oldTools;
                    if (model.Tools != null)
                        removedTools = oldTools.Where(d => !model.Tools.Any(m => m.Id == d.Id)).ToArray();
                    foreach (var item in removedTools)
                    {
                        ctx.HkTool.Remove(item);
                    }

                    // save or update tools
                    foreach (var item in model.Tools)
                    {
                        var dbTool = ctx.HkTool.FirstOrDefault(d => d.Id == item.Id);
                        if (dbTool == null)
                        {
                            dbTool = new HkTool();
                            dbTool.HkProgram = dbProg;
                            ctx.HkTool.Add(dbTool);
                        }

                        dbTool.ToolName = item.ToolName;
                        dbTool.ToolOrder = item.ToolOrder;
                        dbTool.ToolSettings = item.ToolSettings;
                        dbTool.ToolType = item.ToolType;

                        dbTool.HkProgram = dbProg;
                    }

                    // submit changes
                    ctx.SaveChanges();
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public BusinessResult DeleteProgram(int programId)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext ctx = new EyeContext())
                {
                    var dbProg = ctx.HkProgram.FirstOrDefault(d => d.Id == programId);
                    if (dbProg != null)
                    {
                        var dbTools = ctx.HkTool.Where(d => d.ProgramId == programId).ToArray();
                        foreach (var item in dbTools)
                        {
                            ctx.HkTool.Remove(item);
                        }

                        ctx.HkProgram.Remove(dbProg);
                    }

                    ctx.SaveChanges();
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public void Dispose()
        {
            
        }
    }
}
