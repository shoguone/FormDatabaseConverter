using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FormDatabaseConverter.EntityModel;
using FormDatabaseConverter.Utility;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace FormDatabaseConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<MilitaryForces> mForces;
        //private List<MilitaryDistrict> mDistricts;
        //private List<MilitaryTitle> mTitles;
        //private List<Activity> activities;
        //private List<Station> stations;
        //private List<BadRegistry> badRegistries;
        //private List<Education> educations;
        //private List<Railroad> railroads;
        //private List<Department> departments;
        //private List<MarriageStatus> marriage;

        public MainWindow()
        {
            InitializeComponent();

            //using (var ctx = new Old2014_1Context())
            //{
            //    mForces = ctx.VID_VS.Select(v => new MilitaryForces() { Name = v.NAME }).ToList();
            //    mDistricts = ctx.V_OKRUG.Select(v => new MilitaryDistrict() { Name = v.NAME }).ToList();
            //    mTitles = ctx.ZVAN.Select(z => new MilitaryTitle() { Land = z.NAME }).ToList();
            //    activities = ctx.DO_PRIZ.Select(z => new Activity() { Name = z.NAME }).ToList();
            //    stations = ctx.GORODA.Select(z => new Station() { Name = z.NAME }).ToList();
            //    badRegistries = ctx.NA_UCHETE.Select(z => new BadRegistry() { Name = z.NAME }).ToList();
            //    educations = ctx.OBRAZ.Select(z => new Education() { Name = z.NAME }).ToList();
            //    railroads = ctx.RAILROAD.Select(z => new Railroad() { Name = z.NAME }).ToList();
            //    departments = ctx.RVK.Select(z => new Department() { NameFull = z.NAME, NameShort = z.NAME_S }).ToList();
            //    marriage = ctx.SEM_POL.Select(z => new MarriageStatus() { Name = z.NAME }).ToList();

            //}

            //using (var ctx = new BrandNewContext())
            //{
            //    var b = ctx.Recruits
            //        .Where(r => r.ArrivalDate < DateTime.Now)
            //        .ToList();

            //}


            Init();
        }

        private void Init()
        {
            string generalDBConnectionString = ConfigurationManager
                .ConnectionStrings["Old2014_1Context"]
                .ConnectionString;

            FirebirdFilePath generalDBFile = new FirebirdFilePath(generalDBConnectionString, true);

            var fs = Directory.GetFiles(generalDBFile.ExternalDirectory);
            List<FirebirdFilePath> DBFiles = fs
                .Reverse()
                .Select(f => new FirebirdFilePath(f, false))
                .ToList();

            //string curYear = newDBFiles[0].Year;
            //int fCnt = newDBFiles.Count();
            //for (int i = 0; i < fCnt; i++)
            //{
            //    if (newDBFiles[i].Year != curYear)
            //    {
            //        var separator = new FirebirdFilePath() { Path = "-" };
            //        newDBFiles.Insert(i, separator);

            //        i++;
            //        curYear = newDBFiles[i].Year;
            //        fCnt++;
            //    }
            //}

            //SelectDBComboBox.ItemsSource = newDBFiles;

            //var defaultSeason = newDBFiles.First(f => f.Year.Equals(defaultYear) && f.Number.Equals(defaultNumber));
            //if (defaultSeason != null)
            //    SelectDBComboBox.SelectedItem = defaultSeason;

            //FillTables.FillCompetency();
            //FillTables.FillMilitaryTitle();
            foreach (var fbf in DBFiles)
            {
                //FillMilitaryForces(fbf);
                //FillTables.FillSeason(fbf);
                //FillTables.FillDepartment(fbf);
                //FillTables.FillChosenRecruit(fbf);
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
                    if (!ctxg.MilitaryForces.Any(mf => mf.Name.Equals(entity.NAME)))
                    {
                        ctxg.MilitaryForces.AddObject(new MilitaryForces() { Name = entity.NAME });
                    }
                }

                ctxg.SaveChanges();
            }

        }

    }
}
