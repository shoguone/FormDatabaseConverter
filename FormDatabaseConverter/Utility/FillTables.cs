using FormDatabaseConverter.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDatabaseConverter.Utility
{
    public static class FillTables
    {
        public static void FillActivity(FirebirdFilePath dbFile)
        {
            List<DO_PRIZ> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.DO_PRIZ.ToList();
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

        public static void FillBadRegistry(FirebirdFilePath dbFile)
        {
            List<NA_UCHETE> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.NA_UCHETE.ToList();
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

        public static void FillSeason(FirebirdFilePath dbFile)
        {
            using (BrandNewContext ctxg = new BrandNewContext())
            {
                if (!ctxg.Season.Any(e => e.Year == dbFile.Year && e.Number == dbFile.Number))
                {
                    ctxg.Season.AddObject(new Season() { Year = dbFile.Year, Number = dbFile.Number });
                }

                ctxg.SaveChanges();
            }

        }

        public static void FillDepartment(FirebirdFilePath dbFile)
        {
            List<RVK> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.RVK.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                Season season = ctxg.Season.FirstOrDefault(s => s.Number == dbFile.Number && s.Year == dbFile.Year);
                if (season == default(Season))
                {
                    season = new Season() { Number = dbFile.Number, Year = dbFile.Year };
                }

                foreach (var entity in entities)
                {
                    if (!ctxg.Department.Any(e => e.NameShort == entity.NAME && 
                        e.Season.Year == dbFile.Year && 
                        e.Season.Number == dbFile.Number))
                    {
                        ctxg.Department.AddObject(new Department() { NameShort = entity.NAME, NameFull = entity.NAME_S, Season = season });
                    }
                }

                ctxg.SaveChanges();
            }

        }

        public static void FillChosenRecruit(FirebirdFilePath dbFile)
        {
            List<KN_P> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
            {
                entities = ctxFB.KN_P.ToList();
            }

            using (BrandNewContext ctxg = new BrandNewContext())
            {
                foreach (var entity in entities)
                {
                    DateTime birthDate;
                    DateTime.TryParse(entity.D_ROD, out birthDate);

                    #region debugshit
                    /*
                    List<ChosenRecruit> a1 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a2 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a3 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a4 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a5 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a51 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a52 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a53 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a6 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a7 = new List<ChosenRecruit>();
                    List<ChosenRecruit> a8 = new List<ChosenRecruit>();
                    try
                    {
                        a1 = ctxg.ChosenRecruit.Where(e => e.LastName == entity.FAM).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a2 = a1.Where(e => e.FirstName == entity.IM).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a3 = a2.Where(e => e.MiddleName == entity.OTCH).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a4 = a3.Where(e => e.BirthDate.Value.Year == birthDate.Year).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a51 = a4.Where(e => e.Department_ID.HasValue).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a52 = a4.Where(e => string.IsNullOrEmpty(entity.RVK)).ToList();
                    }
                    catch
                    {
                    }
                    //try
                    //{
                    //    a53 = a4.Where(e => e.Department.NameShort == entity.RVK).ToList();
                    //}
                    //catch
                    //{
                    //}
                    try
                    {
                        a5 = a4.Where(e => !e.Department_ID.HasValue && string.IsNullOrEmpty(entity.RVK) || 
                            e.Department_ID.HasValue && e.Department.NameShort == entity.RVK).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a6 = a5.Where(e => e.Destination == entity.KUDA).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a7 = a6.Where(e => string.IsNullOrEmpty(e.Patron) && string.IsNullOrEmpty(entity.KTO) || e.Patron == entity.KTO).ToList();
                    }
                    catch
                    {
                    }
                    try
                    {
                        a8 = a7.Where(e => e.Season.Year == dbFile.Year && e.Season.Number == dbFile.Number).ToList();
                    }
                    catch (Exception)
                    {
                    }
                    */
                    #endregion

                    //if (!ctxg.ChosenRecruit.Any(e => e.Equals(entity, dbFile.Number, dbFile.Year)))
                    if (!ctxg.ChosenRecruit.Any(e =>
                        (string.IsNullOrEmpty(e.LastName) && string.IsNullOrEmpty(entity.FAM) || e.LastName == entity.FAM) &&
                        (string.IsNullOrEmpty(e.FirstName) && string.IsNullOrEmpty(entity.IM) || e.FirstName == entity.IM) &&
                        (string.IsNullOrEmpty(e.MiddleName) && string.IsNullOrEmpty(entity.OTCH) || e.MiddleName == entity.OTCH) &&
                        (!e.BirthDate.HasValue && birthDate == null || e.BirthDate.Value.Year == birthDate.Year) &&
                        (!e.Department_ID.HasValue && string.IsNullOrEmpty(entity.RVK) || e.Department_ID.HasValue && e.Department.NameShort == entity.RVK) &&
                        (string.IsNullOrEmpty(e.Destination) && string.IsNullOrEmpty(entity.KUDA) || e.Destination == entity.KUDA) &&
                        (string.IsNullOrEmpty(e.Patron) && string.IsNullOrEmpty(entity.KTO) || e.Patron == entity.KTO) &&
                        e.Season.Year == dbFile.Year && e.Season.Number == dbFile.Number
                        ))
                    {
                        Season season = ctxg.Season.FirstOrDefault(s => s.Number == dbFile.Number && s.Year == dbFile.Year);
                        if (season == default(Season))
                        {
                            season = new Season() { Number = dbFile.Number, Year = dbFile.Year };
                        }

                        Department dept = ctxg.Department.FirstOrDefault(d => d.NameShort.Equals(entity.RVK) && 
                            d.Season.Year == dbFile.Year && d.Season.Number == dbFile.Number);
                        if (dept == default(Department))
                        {
                            //dept = new Department() { NameShort = entity.RVK };
                        }
                        
                        ctxg.ChosenRecruit.AddObject(new ChosenRecruit()
                        {
                            LastName = entity.FAM,
                            FirstName = entity.IM,
                            MiddleName = entity.OTCH,
                            BirthDate = birthDate,
                            Department = dept,
                            Destination = entity.KUDA,
                            Patron = entity.KTO,
                            Season = season
                        });
                    }
                    //else
                    //{
                    //    var a = 0;
                    //}
                }

                ctxg.SaveChanges();
            }

        }

        public static void FillCompetency()
        {
            using (BrandNewContext ctxg = new BrandNewContext())
            {
                if (ctxg.Competency.Count() < 1)
                {
                    ctxg.Competency.AddObject(new Competency() { Name = "I" });
                    ctxg.Competency.AddObject(new Competency() { Name = "II" });
                    ctxg.Competency.AddObject(new Competency() { Name = "III" });
                    //ctxg.Competency.AddObject(new Competency() { Name = "IV" });

                    ctxg.SaveChanges();
                }

            }

        }

        public static void FillMilitaryTitle()
        {
            using (BrandNewContext ctxg = new BrandNewContext())
            {
                if (ctxg.MilitaryTitle.Count() < 1)
                {
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 1, 
                        Land = "рядовой",
                        Marine = "матрос"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 2,
                        Land = "ефрейтор",
                        Marine = "ст. матрос"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 3,
                        Land = "мл. сержант",
                        Marine = "старшина 2 ст."
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 4,
                        Land = "сержант",
                        Marine = "старшина 1 ст."
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 5,
                        Land = "ст. сержант",
                        Marine = "главный старшина"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 5,
                        Land = "старшина",
                        Marine = "главный корабельный старшина"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 6,
                        Land = "прапорщик",
                        Marine = "мичман"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 7,
                        Land = "ст. прапорщик",
                        Marine = "ст. мичман"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 8,
                        Land = "мл. лейтенант",
                        Marine = "мл. лейтенант"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 9,
                        Land = "лейтенант",
                        Marine = "лейтенант"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 10,
                        Land = "ст. лейтенант",
                        Marine = "ст. лейтенант"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 11,
                        Land = "капитан",
                        Marine = "капитан-лейтенант"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 12,
                        Land = "майор",
                        Marine = "капитан 3 ранга"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 13,
                        Land = "подполковник",
                        Marine = "капитан 2 ранга"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 14,
                        Land = "полковник",
                        Marine = "капитан 1 ранга"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 15,
                        Land = "генерал-майор",
                        Marine = "контр-адмирал"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 16,
                        Land = "генерал-лейтенант",
                        Marine = "вице-адмирал"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 17,
                        Land = "генерал-полковник",
                        Marine = "адмирал"
                    });
                    ctxg.MilitaryTitle.AddObject(new MilitaryTitle()
                    {
                        Rank = 18,
                        Land = "генерал армии",
                        Marine = "адмирал флота"
                    });

                    ctxg.SaveChanges();
                }

            }

        }

        public static void FillMilitaryDistrict(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        /**
        public static void FillDeputy(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillDismissal(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillDriverLicense(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillDutyForm(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillEchelon(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillEducation(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillFamilyStatus(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillMarriageStatus(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillMedicineCategory(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillMedicineDegree(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillMilitaryCertificate(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillMilitaryForces(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillMilitaryUnit(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillNeuroPsychicStability(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillOrderSoldier(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillPermission(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillPermissionForm(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillPhone(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillRailroad(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillRecruit(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillRecruitsLog(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillRecruitSport(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillRelative(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillReturn(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillSelfDesiredAbsence(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillSpeciality(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillSportCategory(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillSportType(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillSquad(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillSquadDuty(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillSquadron(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillStation(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillTDT(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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

        public static void FillToken(FirebirdFilePath dbFile)
        {
            List<VID_VS> entities;
            using (Old2014_1Context ctxFB = new Old2014_1Context(dbFile.ConnectionString))
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
        /**/

    }
}

