using FormDatabaseConverter.EntityModel;
using FormDatabaseConverter.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDatabaseConverter.Templates
{
    public class FillTablesGenerator
    {
        private void FillActivity(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Activity.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Activity.AddObject(new Activity() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillBadRegistry(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.BadRegistry.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.BadRegistry.AddObject(new BadRegistry() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillChosenRecruit(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.ChosenRecruit.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.ChosenRecruit.AddObject(new ChosenRecruit() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillCompetency(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Competency.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Competency.AddObject(new Competency() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillDepartment(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Department.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Department.AddObject(new Department() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillDeputy(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Deputy.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Deputy.AddObject(new Deputy() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillDismissal(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Dismissal.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Dismissal.AddObject(new Dismissal() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillDriverLicense(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.DriverLicense.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.DriverLicense.AddObject(new DriverLicense() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillDutyForm(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.DutyForm.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.DutyForm.AddObject(new DutyForm() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillEchelon(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Echelon.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Echelon.AddObject(new Echelon() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillEducation(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Education.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Education.AddObject(new Education() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillFamilyStatus(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.FamilyStatus.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.FamilyStatus.AddObject(new FamilyStatus() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMarriageStatus(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MarriageStatus.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MarriageStatus.AddObject(new MarriageStatus() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMedicineCategory(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MedicineCategory.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MedicineCategory.AddObject(new MedicineCategory() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMedicineDegree(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MedicineDegree.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MedicineDegree.AddObject(new MedicineDegree() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMilitaryCertificate(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MilitaryCertificate.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MilitaryCertificate.AddObject(new MilitaryCertificate() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMilitaryDistrict(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MilitaryDistrict.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MilitaryDistrict.AddObject(new MilitaryDistrict() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMilitaryForces(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MilitaryForces.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MilitaryForces.AddObject(new MilitaryForces() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMilitaryTitle(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MilitaryTitle.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MilitaryTitle.AddObject(new MilitaryTitle() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillMilitaryUnit(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.MilitaryUnit.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.MilitaryUnit.AddObject(new MilitaryUnit() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillNeuroPsychicStability(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.NeuroPsychicStability.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.NeuroPsychicStability.AddObject(new NeuroPsychicStability() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillOrderSoldier(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.OrderSoldier.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.OrderSoldier.AddObject(new OrderSoldier() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillPermission(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Permission.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Permission.AddObject(new Permission() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillPermissionForm(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.PermissionForm.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.PermissionForm.AddObject(new PermissionForm() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillPhone(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Phone.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Phone.AddObject(new Phone() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillRailroad(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Railroad.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Railroad.AddObject(new Railroad() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillRecruit(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Recruit.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Recruit.AddObject(new Recruit() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillRecruitsLog(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.RecruitsLog.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.RecruitsLog.AddObject(new RecruitsLog() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillRecruitSport(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.RecruitSport.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.RecruitSport.AddObject(new RecruitSport() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillRelative(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Relative.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Relative.AddObject(new Relative() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillReturn(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Return.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Return.AddObject(new Return() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSeason(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Season.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Season.AddObject(new Season() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSelfDesiredAbsence(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.SelfDesiredAbsence.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.SelfDesiredAbsence.AddObject(new SelfDesiredAbsence() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSpeciality(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Speciality.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Speciality.AddObject(new Speciality() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSportCategory(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.SportCategory.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.SportCategory.AddObject(new SportCategory() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSportType(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.SportType.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.SportType.AddObject(new SportType() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSquad(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Squad.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Squad.AddObject(new Squad() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSquadDuty(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.SquadDuty.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.SquadDuty.AddObject(new SquadDuty() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillSquadron(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Squadron.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Squadron.AddObject(new Squadron() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillStation(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Station.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Station.AddObject(new Station() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillTDT(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.TDT.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.TDT.AddObject(new TDT() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        private void FillToken(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using(Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.VID_VS.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    if (!ctxg.Token.Any(e => e.Name.Equals(entity.NAME)))
                    {
                        ctxg.Token.AddObject(new Token() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

    }
}

