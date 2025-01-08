using AutoMapper;
using EliteAthleteAppShared.Contracts;
using EliteAthleteAppShared.Data;
using Microsoft.AspNetCore.Identity;
using EliteAthleteAppShared.Models.TrainingPlan;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Microsoft.IdentityModel.Tokens;

namespace EliteAthleteAppShared.Services
{
    public class PdfService : IPdfService
    {
        private readonly ITrainingModuleRepository trainingModuleRepository;
        private readonly ITrainingPlanRepository trainingPlanRepository;

        public PdfService(
            ITrainingModuleRepository trainingModuleRepository,
            ITrainingPlanRepository trainingPlanRepository)
        {
            this.trainingModuleRepository = trainingModuleRepository;
            this.trainingPlanRepository = trainingPlanRepository;
        }
        // GENERATES TRAINING MODULE IN PDF
        public async Task<byte[]> GetTrainingModulePDFAsync(int trainingModuleId)
        {
            List<int> trainingPlanIds = (await trainingModuleRepository.GetAsync(trainingModuleId)).TrainingPlanIds;
            List<TrainingPlanDetailsVM> trainingPlanVMs = new List<TrainingPlanDetailsVM>();

            foreach (int id in trainingPlanIds)
            {
                trainingPlanVMs.Add(await trainingPlanRepository.GetTrainingPlanDetailsVMAsync(id));
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Training Plan";
            XFont font = new XFont("Verdana", 20, XFontStyleEx.Bold);

            List<PdfPage> pageList = new List<PdfPage>();
            pageList.Add(document.AddPage());
            XGraphics gfx = XGraphics.FromPdfPage(pageList[0]);

            int tableX = 50;
            int tableY = 50;
            int rowHeight = 15;
            int columnWidth = 110;
            int tableYOffset = 0;

            foreach (var trainingPlanVM in trainingPlanVMs)
            {
                if (!trainingPlanVM.TrainingPlanExerciseDetailVMs.IsNullOrEmpty())
                {
                    if (tableY + trainingPlanVM.TrainingPlanExerciseDetailVMs.Count * 15 > 842)
                    {
                        font = new XFont("Verdana", 8, XFontStyleEx.Bold);
                        gfx.DrawString($"str.{pageList.Count}", font, XBrushes.Black, new XRect(570, 830, 5, 5), XStringFormats.Center);
                        pageList.Add(document.AddPage());
                        tableY = 50;
                        gfx = XGraphics.FromPdfPage(pageList[pageList.Count - 1]);
                    }

                    font = new XFont("Verdana", 20, XFontStyleEx.Bold);
                    gfx.DrawString($"{trainingPlanVM.Name}", font, XBrushes.Black, new XRect(tableX, tableY - 20, columnWidth, rowHeight), XStringFormats.CenterLeft);

                    for (int i = 0; i < trainingPlanVM.TrainingPlanExerciseDetailVMs.Count; i++)
                    {
                        font = new XFont("Verdana", 12, XFontStyleEx.Regular);
                        gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 0, tableY + rowHeight * i, columnWidth + 50, rowHeight);
                        gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 1 + 50, tableY + rowHeight * i, columnWidth, rowHeight);
                        gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 2 + 50, tableY + rowHeight * i, columnWidth, rowHeight);
                        gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 3 + 50, tableY + rowHeight * i, columnWidth, rowHeight);

                        gfx.DrawString($"{trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Index}: {trainingPlanVM.TrainingPlanExerciseDetailVMs[i].ExerciseVM.Name}", font, XBrushes.Black, new XRect(tableX + columnWidth * 0, tableY + rowHeight * i, columnWidth + 50, rowHeight), XStringFormats.CenterLeft);
                        gfx.DrawString($"{trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Sets}x{trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Units}", font, XBrushes.Black, new XRect(tableX + columnWidth * 1 + 50, tableY + rowHeight * i, columnWidth, rowHeight), XStringFormats.Center);
                        gfx.DrawString($"Weight: {trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Weight}", font, XBrushes.Black, new XRect(tableX + columnWidth * 2 + 50, tableY + rowHeight * i, columnWidth, rowHeight), XStringFormats.Center);
                        gfx.DrawString($"Rest: {trainingPlanVM.TrainingPlanExerciseDetailVMs[i].RestTime}", font, XBrushes.Black, new XRect(tableX + columnWidth * 3 + 50, tableY + rowHeight * i, columnWidth, rowHeight), XStringFormats.Center);
                        tableYOffset += 15;
                    }
                    tableY += tableYOffset + 30;
                    tableYOffset = 0;
                }
            }
            font = new XFont("Verdana", 8, XFontStyleEx.Bold);
            gfx.DrawString($"str.{pageList.Count}", font, XBrushes.Black, new XRect(570, 830, 5, 5), XStringFormats.Center);

            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);

                return stream.ToArray();
            }
        }
    }
}
